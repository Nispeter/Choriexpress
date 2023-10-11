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
        }
    }

    public void Pickup()
    {
        if (heldObject == null)
        {
            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * interactDistance, Color.green, 2.0f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
                if (pickupable != null)
                {
                    heldObject = pickupable;

                    Transform objTransform = ((Component)heldObject).transform;
                    objTransform.SetParent(mainCam.transform); 
                    objTransform.localPosition = holdPosition.localPosition;
                    objTransform.localRotation = holdPosition.localRotation;

                    heldObject.OnPickup();
                }
            }
        }
        else
        {
            Transform objTransform = ((Component)heldObject).transform;
            objTransform.SetParent(null); // Remove the object's parent

            Collider objCollider = ((Component)heldObject).GetComponent<Collider>();
            if (objCollider) objCollider.enabled = true; // Reactivate the collider when dropping

            heldObject.OnDrop();
            heldObject = null;
        }
    }


}
