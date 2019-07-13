using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBase : MonoBehaviour
{
    //GO de la bomba que está en la base (Para apagar y prender)
    public GameObject bomb_base;

    //Go de las particulas de la bomba
    public GameObject bombParticle_BASE;

    //Vector 3 para saber dónde se va a instanciar las particulas de explosión
    private Vector3 explosionBombInstanceCoordinates_BASE;
    
    //BoolPara saber si está cerca de un objeto que puede destruir
    private bool hasExploded_BASE = false;

  //Bool para saber si ya la puso en la base
  private bool isAlreadyInBase;

    void Start()
    {
    bomb_base.SetActive(false);
    }

    void Update()
    {
        Debug.Log("hasexploded" + hasExploded_BASE);

        if (Input.GetKeyDown(KeyCode.LeftShift) && hasExploded_BASE == false && isAlreadyInBase == true)
        {
      isAlreadyInBase = false;

      Debug.Log("fsf00");
            explosionBombInstanceCoordinates_BASE = new Vector3(bomb_base.transform.position.x, bomb_base.transform.position.y + 1, bomb_base.transform.position.z);
            Instantiate(bombParticle_BASE, explosionBombInstanceCoordinates_BASE, Quaternion.Euler(-90, 0, 0));
            hasExploded_BASE = true;
            Invoke("BackToLife", 3.3f);
            bomb_base.SetActive(false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && BombPlayer.is_on_base == true)
        {
            bomb_base.SetActive(true);
            isAlreadyInBase = true;
        }
    }

    void BackToLife ()
    {
        hasExploded_BASE = false;

    }

  void deactive()
  {
    bomb_base.SetActive(false);
  }
}
