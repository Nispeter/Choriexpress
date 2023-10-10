using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public float interactDistance = 2.0f;
    public Transform holdPosition; // A transform indicating where in front of the camera the object should be held.
    private IPickupable heldObject;

    private void Update()
    {
        HoldProp();
    }

    private void HoldProp(){
        if(heldObject != null)
        {
            Transform objTransform = ((Component)heldObject).transform;
            objTransform.position = holdPosition.position;
            objTransform.rotation = holdPosition.rotation;
        }
    }

    public void Pickup()
    {
        if (heldObject == null)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
                if (pickupable != null)
                {
                    heldObject = pickupable;
                    heldObject.OnPickup();
                }
            }
        }
        else
        {
            heldObject.OnDrop();
            heldObject = null;
        }
    }
}
