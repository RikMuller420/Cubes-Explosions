using UnityEngine;
using UnityEngine.EventSystems;

public class Fragmentator : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Fragmentator _prefab;
    [SerializeField] private int _minSplitCount = 2;
    [SerializeField] private int _maxSplitCount = 6;
    [SerializeField, Min(1f)] private float _scaleReducing = 2f;
    [SerializeField, Min(1f)] private float _splitChanceReducing = 2f;
    [SerializeField] private float _explosionForce = 100f;

    private float _splitChancePercent = 100f;
    private float _maxSplitPercent = 100f;
    private float _explosionRadius = 5f;

    public void OnPointerClick(PointerEventData eventData)
    {
        Split();
    }

    private void Split()
    {
        float splitChance = Random.Range(1, _maxSplitPercent);

        if (splitChance <= _splitChancePercent)
        {
            CreatePieces();
        }

        Destroy(this);
    }

    private void CreatePieces()
    {
        int fragmentCount = Random.Range(_minSplitCount, _maxSplitCount);

        for (int i = 0; i < fragmentCount; i++)
        {
            CreatePiece();
        }
    }

    private void CreatePiece()
    {
        Fragmentator fragment = Instantiate(_prefab, transform.parent);

        fragment.SetNewSplitChance(_splitChancePercent / _splitChanceReducing);
        fragment.transform.localScale = transform.localScale / _scaleReducing;
        fragment.SetRandomColor();
        fragment.AddSplitForce(transform.position);
    }

    private void SetRandomColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    private void SetNewSplitChance(float splitChancePercent)
    {
        _splitChancePercent = splitChancePercent;
    }

    private void AddSplitForce(Vector3 splitPosition)
    {
        _rigidbody.AddExplosionForce(_explosionForce, splitPosition, _explosionRadius);
    }


    private void OnValidate()
    {
        if (_maxSplitCount < _minSplitCount)
        {
            _maxSplitCount = _minSplitCount;
        }
    }
}
