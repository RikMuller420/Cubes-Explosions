using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class SplittableCube : MonoBehaviour
{
    [SerializeField] public float SplitChancePercent = 100f;

    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;

    public MeshRenderer Renderer { get => _renderer; }
    public Rigidbody Rigidbody { get => _rigidbody; }
}
