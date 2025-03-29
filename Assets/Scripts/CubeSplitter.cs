using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private LayerMask _cubes;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private FragmentCreator _fragmentCreator;
    [SerializeField] private ExplosionCreator _explosionCreator;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _inputHandler.LeftMouseButtonClicked += TrySplitCubeInClickPosition;
    }

    private void OnDisable()
    {
        _inputHandler.LeftMouseButtonClicked -= TrySplitCubeInClickPosition;
    }

    private void TrySplitCubeInClickPosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _cubes))
        {
            if (hit.collider.TryGetComponent(out SplittableCube splittableCube))
            {
                SplitCube(splittableCube);
            }
        }
    }

    public void SplitCube(SplittableCube splittableCube)
    {
        Destroy(splittableCube.gameObject);

        if (_fragmentCreator.TryCreateFragments(splittableCube, out List<SplittableCube> fragments))
        {
            _explosionCreator.ExplodeFragments(splittableCube, fragments);
        }
        else
        {
            _explosionCreator.CreateExplosion(splittableCube);
        }
    }
}
