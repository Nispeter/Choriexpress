
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHintController : MonoBehaviour
{
    public Text hintText;
    public string pickupKey = "Mouse Left Click";
    private Vector3 offset = new Vector3(15, -15, 0); 

    private void Update()
    {
        if (hintText.enabled)
        {
            hintText.transform.position = Input.mousePosition + offset;
        }
    }

    public void ShowHint()
    {
        hintText.text = $"Press {pickupKey} to pick up";
        hintText.enabled = true;
    }

    public void HideHint()
    {
        hintText.enabled = false;
    }
}