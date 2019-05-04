using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Push : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && S_Player.ItemNumber == 2)
        {
            Debug.Log("??");
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        }
    }
}
