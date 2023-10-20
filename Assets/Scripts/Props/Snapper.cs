using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class snapToTable : MonoBehaviour
{

    // Start is called before the first frame update
    //private BoxCollider _collider;
    //public float boxColliderSize;
    public float snapOffsetX;
    public float snapOffsetY;
    public float snapOffsetZ;
    private bool _beingUsed;
    private int limit = 1000000;
    private int counter = 0;
    private void Start()
    {
        //_collider = GetComponent<BoxCollider>();
        // if (!_collider)
        // {
        //     _collider = gameObject.AddComponent<SphereCollider>();
        //     _collider.size = (float)0.3;
        // }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     //Debug.Log("HIT");
    //     if ((collision.gameObject.tag == "Package" || !(_beingUsed && collision.gameObject.GetComponent<Package>().isOnTable)))
    //     {
    //         Package package = collision.gameObject.GetComponent<Package>();
    //         if (counter < limit && package.isCursed)
    //         {
    //             _beingUsed = true;
    //             collision.rigidbody.isKinematic = true;
    //             //collision.rigidbody.isKinematic = true;
    //             //collision.rigidbody.useGravity = false;
    //             Vector3 offset = Vector3.zero;
    //             offset.x += snapOffsetX;
    //             offset.y += snapOffsetY;
    //             offset.z += snapOffsetZ;
    //             collision.transform.position = gameObject.transform.position + offset;
    //             collision.transform.rotation = gameObject.transform.rotation;
    //             collision.rigidbody.isKinematic = false;
    //             package.OnDrop();
    //             package.isOnTable = true;
    //         }
    //         counter++;
    //     }
    // }
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("HIT");
        if ((other.gameObject.tag == "Package" || !(_beingUsed && other.gameObject.GetComponent<Package>().isOnTable)))
        {
            GameObject collision = other.GameObject();
            Package package = collision.gameObject.GetComponent<Package>();
            if (counter < limit && package.isCursed && !_beingUsed)
            {
                _beingUsed = true;
                package.isPickeable = false;
                collision.GetComponent<Rigidbody>().isKinematic = true;
                package.type = "Purificar maldición";
                //collision.rigidbody.useGravity = false;
                // Vector3 offset = Vector3.zero;
                // offset.x += snapOffsetX;
                // offset.y += snapOffsetY;
                // offset.z += snapOffsetZ;
                // collision.transform.position = gameObject.transform.position + offset;
                // collision.transform.rotation = gameObject.transform.rotation;
                StartCoroutine(Deskinematizador(collision));
                //collision.GetComponent<Rigidbody>().isKinematic = false;
                //package.isOnTable = true;
            }
            counter++;
        }
    }

    IEnumerator Deskinematizador(GameObject collision)
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 offset = Vector3.zero;
        offset.x += snapOffsetX;
        offset.y += snapOffsetY;
        offset.z += snapOffsetZ;
        collision.transform.position = gameObject.transform.position + offset;
        collision.transform.rotation = gameObject.transform.rotation;
        // collision.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // collision.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Package package = collision.GetComponent<Package>();
        package.isOnTable = true;
        yield return new WaitUntil(() => package.isCursed == false);
        collision.GetComponent<Rigidbody>().isKinematic = false;
        package.type = "Tomar paquete";
        _beingUsed = false;
        package.isOnTable = false;
        package.isPickeable = true;
        package.OnDrop();
    }
}
