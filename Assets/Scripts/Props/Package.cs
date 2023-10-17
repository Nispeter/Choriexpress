using UnityEngine;
using TMPro;

public class Package : MonoBehaviour, IPickupable
{
    public string type { get; set; }
    public bool isPickedUp { get; set; }
    private Rigidbody rb;
    public bool isPickeable { get; set;  }
    public bool isCursed { get; set; }
    public GameObject curseUI;
    public TextMeshProUGUI curseText;  
    
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

    public void FailedCurse(){
        // MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // meshRenderer.material.color = Color.red;
        curseUI.SetActive(false);
        DayManager.Instance.InGameUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        PointCounter.Instance.SubScore(200);
        
    }

    public void Interact()
    {
        if (!isPickedUp)
        {
            // 
            if(isCursed){
                curseUI.SetActive(true);
                DayManager.Instance.InGameUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }else{
                OnPickup();
            }

        }
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
    public void DeactivateCurse(){
        curseUI.SetActive(false);
        DayManager.Instance.InGameUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        // MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // meshRenderer.material.color = Color.green;
        PointCounter.Instance.AddScore(100);
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
