using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBase : MonoBehaviour
{
    public GameObject bomb_base;

    void Start()
    {
        bomb_base.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            bomb_base.SetActive(false);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Bomb.is_on_base == true)
        {
            //Debug.Log("Bomba?");
            bomb_base.SetActive(true);
        }
    }
}
