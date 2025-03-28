using System.Collections.Generic;
using UnityEngine;

public class FragmentExplosionCreator : MonoBehaviour
{
    [SerializeField, Min(10f)] private float _fragmentExplosionForce = 100f;
    [SerializeField, Min(0.2f)] private float _fragmentExplosionRadius = 1f;

    public void ExplodeFragments(Vector3 explodePoint, List<SplittableCube> fragments)
    {
        foreach (SplittableCube fragment in fragments)
        {
            fragment.Rigidbody.AddExplosionForce(
                _fragmentExplosionForce,
                explodePoint,
                _fragmentExplosionRadius
            );
        }
    }
}
