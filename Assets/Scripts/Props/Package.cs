using UnityEngine;

public class Package : MonoBehaviour, IPickupable
{
    private bool isPickedUp = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            Debug.LogWarning("No Rigidbody found on Package object. Adding one by default.");
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    public void OnPickUp()
    {
        if(!isPickedUp)
        {
            Debug.Log("Picked up the package!");

            if (rb)
            {
                rb.useGravity = false;
                rb.velocity = Vector3.zero; 
            }
            
            isPickedUp = true;
        }
    }

    public void OnDrop()
    {
        if(isPickedUp)
        {
            Debug.Log("Dropped the package!");

            if (rb)
            {
                rb.useGravity = true;
            }

            isPickedUp = false;
        }
    }
}
