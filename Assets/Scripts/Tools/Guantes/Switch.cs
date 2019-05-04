using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject puerta;
    // Start is called before the first frame update
    void Start()
    {
        puerta.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="LaCaja"||other.tag=="Player")
            puerta.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LaCaja" || other.tag == "Player")
            puerta.SetActive(true);
    }
}
