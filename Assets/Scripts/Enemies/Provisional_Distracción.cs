using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provisional_Distracción : MonoBehaviour
{
    public Transform pilar1, pilar2, bomb;
    private Vector3 OG;
    private float OGx, OGy, OGz;
    public float speed;
    bool act = false;

    void Start()
    {

    }

    void Update()
    {
        //Debug.Log(act);

        if (Input.GetKeyDown(KeyCode.Alpha1) && act == false)
        {
            OGx = this.transform.position.x;
            OGy = this.transform.position.y;
            OGz = this.transform.position.z;
            act = true;
        }

        if (act)
        {
            transform.position = Vector3.MoveTowards(transform.position, pilar1.position, speed * Time.deltaTime);
            Invoke("rayos", 3);
        }
    }

    void rayos()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(OGx, OGy, OGz), speed * Time.deltaTime);
        act = false;
    }
}
