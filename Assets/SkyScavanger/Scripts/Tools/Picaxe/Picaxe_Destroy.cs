using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picaxe_Destroy : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && S_Player.ItemNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
