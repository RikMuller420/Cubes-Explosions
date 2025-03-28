using UnityEngine;

public class CubeExplosionCreator : MonoBehaviour
{
    [SerializeField, Min(10f)] private float _baseExplosionForce = 100f;
    [SerializeField, Min(0.2f)] private float _explosionForceBoostByScale = 0.9f;
    [SerializeField, Min(0.2f)] private float _baseExplosionRange = 3f;
    [SerializeField, Min(0.2f)] private float _explosionRangeBoostByScale = 0.75f;

    public void CreateExplosion(SplittableCube explodedCube)
    {
        float scale = explodedCube.transform.lossyScale.magnitude;
        float explodeForce = _baseExplosionForce / scale * _explosionForceBoostByScale;
        float explodeRadius = _baseExplosionRange / scale * _explosionRangeBoostByScale;
        Collider[] hitColliders = Physics.OverlapSphere(explodedCube.transform.position, explodeRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.TryGetComponent(out SplittableCube cube))
            {
                cube.Rigidbody.AddExplosionForce(
                    explodeForce,
                    explodedCube.transform.position,
                    explodeRadius
                );
            }
        }
    }
}
