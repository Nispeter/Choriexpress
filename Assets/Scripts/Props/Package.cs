using UnityEngine;

public class Package : MonoBehaviour, IPickupable
{
    public string type { get; set; }
    public bool isPickedUp { get; set; }
    private Rigidbody rb;
    public bool isPickeable { get; set;  }
    public bool isCursed { get; set; }

    private void Start()
    {
        type = "pickup";
        isPickeable = true;
        isCursed = true;
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    public void Interact()
    {
        if (!isPickedUp)
            OnPickup();
        else
            OnDrop();
    }

    public void OnPickup()
    {

        if (rb)
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
        }

        isPickedUp = true;

    }

    public void OnDrop()
    {

        if (rb)
        {
            rb.useGravity = true;
        }

        isPickedUp = false;

    }
}
