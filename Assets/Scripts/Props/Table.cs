using UnityEngine;

public class Table : MonoBehaviour, IInteractable
{
    public string type { get; set; } = "interact";
    public void Interact()
    {
        Debug.Log("The table has an item above it. Doing something...");
    }
    /*public string type { get; set; } = "interact";

    private float checkHeight = 1.5f;
    private float checkRadius = 0.5f; 

    public LayerMask itemLayer; 

    public void Interact()
    {
        if (HasItemAbove())
        {
            Debug.Log("The table has an item above it. Doing something...");
        }
        else
        {
            Debug.Log("The table doesn't have any item above it.");
        }
    }

    private bool HasItemAbove()
    {

        Collider[] itemsAbove = Physics.OverlapSphere(transform.position + new Vector3(0, checkHeight, 0), checkRadius, itemLayer);

        return itemsAbove.Length > 0;
    }*/
}
