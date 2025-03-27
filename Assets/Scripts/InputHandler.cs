using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private CubeSplitter _cubeSplitter;

    private void Update()
    {
        bool isClicked = Mouse.current.leftButton.wasPressedThisFrame;

        if (isClicked)
        {
            _cubeSplitter.TrySplitCubeInClickPosition();
        }
    }
}
