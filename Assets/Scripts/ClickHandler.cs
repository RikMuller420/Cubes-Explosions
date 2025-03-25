using UnityEngine;
using UnityEngine.InputSystem;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _cubes;

    private void Update()
    {
        bool isClicked = Mouse.current.leftButton.wasPressedThisFrame;

        if (isClicked)
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _cubes))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.TryGetComponent<Fragmentator>(out Fragmentator fragmentator))
            {
                fragmentator.Split();
            }
        }
    }
}
