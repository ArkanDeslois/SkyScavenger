using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDesbloqueada : MonoBehaviour
{
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
    if (other.gameObject.tag == "PilarCaer(SoloPrueba)")
    {
      Debug.Log("Hello?");
      this.gameObject.SetActive(false);
    }
  }
}
