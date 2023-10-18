using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTPMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.SetActive(false);
        }
    }
}
