using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action LeftMouseButtonClicked;

    private void Update()
    {
        bool isClicked = Mouse.current.leftButton.wasPressedThisFrame;

        if (isClicked)
        {
            LeftMouseButtonClicked?.Invoke();
        }
    }
}
