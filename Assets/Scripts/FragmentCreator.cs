using System.Collections.Generic;
using UnityEngine;

public class FragmentCreator : MonoBehaviour
{
    [SerializeField] private SplittableCube _piecePrefab;
    [SerializeField] private int _minSplitCount = 2;
    [SerializeField] private int _maxSplitCount = 6;
    [SerializeField, Min(1f)] private float _scaleReduction = 2f;
    [SerializeField, Min(1f)] private float _splitChanceReduction = 2f;

    private float _maxSplitPercent = 100f;

    private void OnValidate()
    {
        if (_maxSplitCount < _minSplitCount)
        {
            _maxSplitCount = _minSplitCount;
        }
    }

    public List<SplittableCube> CreateFragments(SplittableCube parent)
    {
        List<SplittableCube> fragments = new List<SplittableCube>();
        float splitChance = Random.Range(1, _maxSplitPercent);

        if (splitChance > parent.SplitChancePercent)
        {
            return fragments;
        }

        int fragmentCount = Random.Range(_minSplitCount, _maxSplitCount);

        for (int i = 0; i < fragmentCount; i++)
        {
            fragments.Add(CreateFragment(parent));
        }

        return fragments;
    }

    private SplittableCube CreateFragment(SplittableCube parent)
    {
        SplittableCube fragment = Instantiate(_piecePrefab, parent.transform.parent);

        fragment.transform.localScale = parent.transform.localScale / _scaleReduction;
        fragment.transform.position = parent.transform.position;

        Color randomColor = new Color(Random.value, Random.value, Random.value);
        fragment.Renderer.material.color = randomColor;

        float splitChance = parent.SplitChancePercent / _splitChanceReduction;
        fragment.SplitChancePercent = splitChance;

        return fragment;
    }
}
