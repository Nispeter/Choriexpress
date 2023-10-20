using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class Package : MonoBehaviour, IPickupable
{
    public string type { get; set; }
    public bool isPickedUp { get; set; }
    private Rigidbody rb;
    public bool isPickeable { get; set; }
    public bool isCursed { get; set; }
    public GameObject curseUI;
    public TextMeshProUGUI curseText;
    public AudioSource SFX;
    public AudioClip SFX_CleansedCurse;
    public AudioClip SFX_FailedCurse;
    public AudioClip SFX_PickUp;
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

    public void FailedCurse()
    {
        // MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // meshRenderer.material.color = Color.red;
        Debug.Log("CURSE FAILED");
        GetComponentInChildren<TMP_InputField>().text = "";
        curseUI.SetActive(false);
        DayManager.Instance.InGameUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PointCounter.Instance.SubScore(100);
        SFX.clip = SFX_FailedCurse;
        SFX.Play();

    }

    public void Interact()
    {
        if (!isPickedUp && SFX)
        {
            SFX.clip = SFX_PickUp;
            SFX.Play();

            if (isCursed && curseUI && DayManager.Instance)
            {
                curseUI.SetActive(true);
                DayManager.Instance.InGameUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                var inputField = GetComponentInChildren<TMP_InputField>();
                if (inputField) inputField.Select();
            }
            else
            {
                OnPickup();
            }
        }
        else
        {
            OnDrop();
        }
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
    public void DeactivateCurse()
    {
        curseUI.SetActive(false);
        DayManager.Instance.InGameUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // meshRenderer.material.color = Color.green;
        SFX.clip = SFX_CleansedCurse;
        SFX.Play();

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
