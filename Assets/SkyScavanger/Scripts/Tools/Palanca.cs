using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    //Temporal, estas cosas son el replacement de la animación de la palanca activada o desactivada
    public GameObject palancaActiva, palancaDesactivada;

    //Bool para saber si está activada o desactivada la palanaca
    public bool activa = false, isOnLever;

    //GameObject de la mierda que se va a mover con esta palanca
    public Animator holderObjetivo;

    void Start()
    {
        //Temporal, se prenden y apagan los objetos que funcionan como la anumación de la palanaca. 
        palancaActiva.SetActive(false);
        palancaDesactivada.SetActive(true);

        //Se prende y apaga la bandera para avisarnos si la palanca está activa... En el start está desactivada
        isOnLever = false;
    }

    void Update()
    {
        if (isOnLever == true && Input.GetKeyDown(KeyCode.Space))
        {
            //Si está desactivada entonces pasa a verdadera
            if (activa == false)
            {
                //Cambio de estado del bool
                activa = true;

                //Cambio de "animación" de la palanca
                palancaDesactivada.SetActive(false);
                palancaActiva.SetActive(true);
            }
            else
            {
                //Cambio de estado del bool
                activa = false;

                //Cambio de "animación" de la palanca
                palancaDesactivada.SetActive(true);
                palancaActiva.SetActive(false);
            }

            ////Si está activa entonces pasa a falsa
            //if (activa == true)
            //{
            //    //Cambio de estado del bool
            //    activa = false;

            //    //Cambio de "animación" de la palanca
            //    palancaDesactivada.SetActive(true);
            //    palancaActiva.SetActive(false);
            //}
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M");
            //agarramos el animator del holder que se va a mover
            holderObjetivo = holderObjetivo.GetComponent<Animator>();

            holderObjetivo.SetBool("Activa", true);
            holderObjetivo.Play("CuboEnMovimiento");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isOnLever = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isOnLever = false;
        }
    }
}
