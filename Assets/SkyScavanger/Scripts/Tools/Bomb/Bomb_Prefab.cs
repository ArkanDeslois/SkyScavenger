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
        if (other.tag == "R_O")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                other.gameObject.SetActive(false);
            }
           }
        }
    }

