using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class SplittableCube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;

    public MeshRenderer Renderer { get => _renderer; }
    public Rigidbody Rigidbody { get => _rigidbody; }
    public float SplitChancePercent { get; private set; } = 100f;

    public void SetSplitChance(float splitChancePercent)
    {
        SplitChancePercent = splitChancePercent;
    }
}
