
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHintController : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public string pickupKey = "Mouse Left Click";
    private Vector3 offset = new Vector3(0, -50, 0); 

    private void Update()
    {
        if (hintText.enabled)
        {
            hintText.transform.position = Input.mousePosition + offset;
        }
    }

    public void ShowHint(string type)
    {
        hintText.text = $"[{pickupKey}] {type}";
        hintText.enabled = true;
    }

    public void HideHint()
    {
        hintText.enabled = false;
    }
}