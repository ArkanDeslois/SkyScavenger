using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaePilar : MonoBehaviour
{
    public bool PilarCaer;
    // Start is called before the first frame update
    void Start()
    {
    PilarCaer = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log(PilarCaer);
      if (Input.GetKeyDown(KeyCode.Q))
      {
        Debug.Log(PilarCaer);
        PilarCaer = (true);
      }
    }
  }
}
