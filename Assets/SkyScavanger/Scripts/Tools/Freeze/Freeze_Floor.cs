using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_Floor : MonoBehaviour
{
    public MeshCollider mC;
    public MeshRenderer mR;
    // Start is called before the first frame update
    void Start()
    {
        mC = this.gameObject.GetComponent<MeshCollider>();
        mR = this.gameObject.GetComponent<MeshRenderer>();
        mR.enabled = false;
        mC.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"&& S_Player.ItemNumber == 4 && Input.GetKeyDown(KeyCode.Q))
        {
            mR.enabled = true;
            mC.enabled = true;
        }
    }
}
