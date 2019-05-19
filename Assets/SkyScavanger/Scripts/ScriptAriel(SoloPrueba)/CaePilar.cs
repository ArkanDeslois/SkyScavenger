using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaePilar : MonoBehaviour
{
    public bool PilarCaer = false;
  bool triggerEntered = false;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Q) && triggerEntered == true)
    {
      PilarCaer = (true);
      this.gameObject.SetActive(false);
    }
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
     // triggerEntered = (true);
     // Debug.Log(PilarCaer);
    }
  }
  private void OnTriggerStay(Collider other)
  {
    if (other.tag == "Player" && S_Player.ItemNumber == 1)
    {
            triggerEntered = (true);
            Debug.Log(PilarCaer);
      if (Input.GetKeyDown(KeyCode.Q))
      {
       // this.gameObject.SetActive(false);
      }
    }
  }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEntered = (false);
        }
    }
}
