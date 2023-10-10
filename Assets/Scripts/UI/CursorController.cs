using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Camera playerCamera;
    public float interactDistance = 3.0f;
    public Texture2D defaultCursor;
    public Texture2D pickupableCursor;

    public UIHintController uiHintController;

    private void Update()
    {
        CheckCursorChange();
    }

    void CheckCursorChange()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
            if (pickupable != null)
            {
                UpdateCursor(pickupableCursor);
                uiHintController.ShowHint();
                return;
            }
        }

        UpdateCursor(defaultCursor);
        uiHintController.HideHint();
    }

    public void UpdateCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
