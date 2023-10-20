using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropHole : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider _collider;
    public float secondsUntilPackageIsDestroyed = 8;

    public AudioSource BoxHittingGround;
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Package")
        {
            Package package = other.GetComponent<Package>();
            if (!package.isCursed)
            {
                Debug.Log("Paquete purificado ha sido lanzado por el agujero");
                PointCounter.Instance.AddScore(200);
                //TODO: Sumar puntos y llamar algún VFX + SFX
            }
            else
            {
                Debug.Log("Paquete maldito ha sido lanzado por el agujero");
                //TODO: RESTAR PUNTOS
            }
            BoxHittingGround.Play();
        }
        
        Debug.Log("Destruyendo objeto");
        Destroy(other.gameObject, 8);
    }
}
