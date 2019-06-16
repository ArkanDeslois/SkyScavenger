using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Prefab : MonoBehaviour
{
    //Go de las particulas de la bomba
    public GameObject bombParticle;

    //Vector 3 para saber dónde se va a instanciar las particulas de explosión
    private Vector3 explosionBombInstanceCoordinates;

    //BoolPara saber si está cerca de un objeto que puede destruir
    private bool isNearARO = false;

    //BoolPara saber si está cerca de un objeto que puede destruir
    private bool hasExploded = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isNearARO == false && hasExploded == false)
        {
            explosionBombInstanceCoordinates = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            Instantiate(bombParticle, explosionBombInstanceCoordinates, Quaternion.identity);
            hasExploded = true;
            Invoke("Kill", 3.3f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "R_O")
        {
            isNearARO = true;
            if (Input.GetKeyDown(KeyCode.LeftShift) && hasExploded == false)
            {
                other.gameObject.SetActive(false);
                explosionBombInstanceCoordinates = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
                Instantiate(bombParticle, explosionBombInstanceCoordinates, Quaternion.identity);
                hasExploded = true;
                Invoke("Kill", 3.3f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "R_O")
        {
            isNearARO = false;
        }
    }

    private void Kill()
    {
        Destroy(this.gameObject);
    }
}    




