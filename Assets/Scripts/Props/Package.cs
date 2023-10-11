using UnityEngine;

public class Package : MonoBehaviour, IPickupable
{
    public bool isPickedUp { get; set; }
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    public void OnPickup()
    {
        if (!isPickedUp)
        {
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
        if (isPickedUp)
        {
            if (rb)
            {
                rb.useGravity = true;
            }

            isPickedUp = false;
        }
    }
}
