using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public float interactDistance = 2.0f;
    public Transform holdPosition; // A transform indicating where in front of the camera the object should be held.
    private IPickupable heldObject;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        CursorController cursorController = FindObjectOfType<CursorController>();
        if (cursorController != null)
        {
            cursorController.SetPlayerCamera(mainCam);
        }
    }

    private void Update()
    {
        HoldProp();
    }

    private void HoldProp()
    {
        if (heldObject != null)
        {
            Transform objTransform = ((Component)heldObject).transform;
            objTransform.localPosition = holdPosition.localPosition;
            objTransform.localRotation = holdPosition.localRotation;
            if (!heldObject.isPickedUp || !heldObject.isPickeable)
            {
                DropHeldObject();
            }
        }
    }

    public void Use()
    {
        // If something is currently held
        if (heldObject != null)
        {
            DropHeldObject();
            return;  // Return immediately after dropping the held object
        }

        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * interactDistance, Color.red, 2.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Try to get the IPickupable component from the hit object
            IPickupable pickupable = hit.collider.GetComponent<IPickupable>();

            // If it's a pickupable object
            if (pickupable != null && pickupable.isPickeable)
            {
                PickupObject(pickupable);
            }
            // If it's not a pickupable object, then check if it's just interactable
            else
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }

    private void DropHeldObject()
    {
        Transform objTransform = ((Component)heldObject).transform;
        objTransform.SetParent(null); // Remove the object's parent

        Collider objCollider = ((Component)heldObject).GetComponent<Collider>();
        if (objCollider) objCollider.enabled = true; // Reactivate the collider when dropping

        heldObject.Interact();
        heldObject = null;
    }

    private void PickupObject(IPickupable pickupable)
    {
        heldObject = pickupable;

        Transform objTransform = ((Component)heldObject).transform;
        objTransform.SetParent(mainCam.transform);
        objTransform.localPosition = holdPosition.localPosition;
        objTransform.localRotation = holdPosition.localRotation;

        heldObject.Interact();
    }
}
