using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Prefab : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "R_DoorBomb")
        {
            Debug.Log("adjgasd");
            if (Input.GetKeyDown(KeyCode.B))
            {
                other.gameObject.SetActive(false);
            }
           }
        }
    }

