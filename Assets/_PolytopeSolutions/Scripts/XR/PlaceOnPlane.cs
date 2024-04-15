using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceOnPlane : MonoBehaviour
{
    public InputAction inputAction;
    public LayerMask placementLayerMask;

    private void Start()
    {
        inputAction.performed += InputAction_performed;
        inputAction.Enable();
    }
    private void OnDestroy()
    {
        inputAction.performed -= InputAction_performed;
        inputAction.Disable();
    }

    private void InputAction_performed(InputAction.CallbackContext obj)
    {
        Vector2 clickPosition = Pointer.current.position.value;
        Ray screenClickRay = Camera.main.ScreenPointToRay(clickPosition);
        if (Physics.Raycast(screenClickRay, out RaycastHit hitInfo, 1000f, placementLayerMask)) { 
            transform.position = hitInfo.point;
            transform.up = hitInfo.normal;
        }
    }
}
