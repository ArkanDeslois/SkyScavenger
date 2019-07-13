using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaePilar : MonoBehaviour
{
    //Se busca en el inspector el animator del pilar que debe caer al destruirse la roca
    public Animator pilar;

    // Start is called before the first frame update
    void Start()
    {
        Animator pilar = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

  private void OnTriggerStay(Collider other)
  {
    if (other.tag == "Player" && S_Player.ItemNumber == 1)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
         pilar.SetBool("PillarIsFalling", true);
         this.gameObject.SetActive(false);
      }
    }
  }
}
