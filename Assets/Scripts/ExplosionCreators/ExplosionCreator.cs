using System.Collections.Generic;
using UnityEngine;

public class ExplosionCreator : MonoBehaviour
{
    [SerializeField] private FragmentExplosionCreator _fragmentExplosionCreator;
    [SerializeField] private CubeExplosionCreator _cubeExplosionCreator;

    internal void CreateExplosion(SplittableCube splittableCube)
    {
        _cubeExplosionCreator.CreateExplosion(splittableCube);
    }

    internal void ExplodeFragments(SplittableCube splittableCube, List<SplittableCube> fragments)
    {
        _fragmentExplosionCreator.ExplodeFragments(splittableCube.transform.position, fragments);
    }
}
