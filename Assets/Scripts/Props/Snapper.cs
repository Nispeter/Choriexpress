using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class snapToTable : MonoBehaviour
{

    // Start is called before the first frame update
    private BoxCollider _collider;
    //public float boxColliderSize;
    public float snapOffsetX;
    public float snapOffsetY;
    public float snapOffsetZ;
    private bool _beingUsed;
    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        // if (!_collider)
        // {
        //     _collider = gameObject.AddComponent<SphereCollider>();
        //     _collider.size = (float)0.3;
        // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
        if (collision.gameObject.name == "Package" || !_beingUsed)
        {
            //collision.rigidbody.useGravity = false;
            Vector3 offset = Vector3.zero;
            offset.x += snapOffsetX;
            offset.y += snapOffsetY;
            offset.z += snapOffsetZ;
            collision.rigidbody.isKinematic = true;
            collision.transform.position = gameObject.transform.position + offset;
            collision.transform.rotation = gameObject.transform.rotation;
            Package package = collision.gameObject.GetComponent<Package>();
            package.isPickeable = false;
            package.isPickedUp = false;

            _beingUsed = true;

        }
    }
}
