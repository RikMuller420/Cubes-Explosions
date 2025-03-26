using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class FragmentCreator : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FragmentCreator _piecePrefab;
    [SerializeField] private int _minSplitCount = 2;
    [SerializeField] private int _maxSplitCount = 6;
    [SerializeField, Min(1f)] private float _scaleReduction = 2f;
    [SerializeField, Min(1f)] private float _splitChanceReduction = 2f;
    [SerializeField, Min(10f)] private float _piecesExplosionForce = 100f;

    private float _splitChancePercent = 100f;
    private float _maxSplitPercent = 100f;

    private void OnValidate()
    {
        if (_maxSplitCount < _minSplitCount)
        {
            _maxSplitCount = _minSplitCount;
        }
    }

    public void Split()
    {
        float splitChance = Random.Range(1, _maxSplitPercent);

        if (splitChance <= _splitChancePercent)
        {
            CreatePieces();
        }

        Destroy(gameObject);
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
        FragmentCreator fragment = Instantiate(_piecePrefab, transform.parent);

        fragment.transform.localScale = transform.localScale / _scaleReduction;
        fragment.transform.position = transform.position;
        fragment.SetSplitChance(_splitChancePercent / _splitChanceReduction);
        fragment.SetRandomColor();
        fragment.AddSplitForce(transform.position);
    }

    private void SetRandomColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    private void SetSplitChance(float splitChancePercent)
    {
        _splitChancePercent = splitChancePercent;
    }

    private void AddSplitForce(Vector3 splitPosition)
    {
        _rigidbody.AddExplosionForce(_piecesExplosionForce, splitPosition, transform.localScale.x);
    }
}
