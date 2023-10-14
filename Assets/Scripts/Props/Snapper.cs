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
        if (collision.gameObject.name == "Package")
        {
            //collision.rigidbody.useGravity = false;
            Vector3 offset = Vector3.zero;
            offset.x += snapOffsetX;
            offset.y += snapOffsetY;
            offset.z += snapOffsetZ;
            collision.transform.position = gameObject.transform.position + offset;
            // collision.rigidbody.useGravity = false;
            // collision.rigidbody.velocity = Vector3.zero;
            // collision.rigidbody.angularVelocity = Vector3.zero;
            collision.rigidbody.isKinematic = true;
        }
    }
}
