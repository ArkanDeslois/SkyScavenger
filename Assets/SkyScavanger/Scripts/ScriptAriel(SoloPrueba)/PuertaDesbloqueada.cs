using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDesbloqueada : MonoBehaviour
{
  public GameObject puerta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("Hello");
    if (other.gameObject.tag == "PilarCaer(SoloPrueba)")
    {
      puerta.SetActive(false);
    }
  }
}
