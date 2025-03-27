using System.Collections.Generic;
using UnityEngine;

public class ExplosionCreator : MonoBehaviour
{
    [SerializeField, Min(10f)] private float _fragmentExplosionForce = 100f;
    [SerializeField, Min(0.2f)] private float _fragmentExplosionRange = 1f;

    public void ExplodeFragments(List<SplittableCube> fragments)
    {
        foreach (SplittableCube fragment in fragments)
        {
            fragment.Rigidbody.AddExplosionForce(
                _fragmentExplosionForce,
                fragment.transform.position,
                _fragmentExplosionRange
            );
        }
    }
}
