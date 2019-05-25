using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    //Temporal, estas cosas son el replacement de la animación de la palanca activada o desactivada
    public GameObject palancaActiva, palancaDesactivada;

    //Bool para saber si está activada o desactivada la palanaca
    public bool activa = false, isOnLever;

    //
    public Animator cubo;

    void Start()
    {
        //Temporal, se prenden y apagan los objetos que funcionan como la anumación de la palanaca. 
        palancaActiva.SetActive(false);
        palancaDesactivada.SetActive(true);

        //Se prende y apaga la bandera para avisarnos si la palanca está activa... En el start está desactivada
        isOnLever = false;

        Animator cubo = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log("isonlever: " + isOnLever);

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

                //animacion del objeto que mueve la palanaca
                cubo.SetBool("Activa", true);
            }
            else
            {
                //Cambio de estado del bool
                activa = false;

                //Cambio de "animación" de la palanca
                palancaDesactivada.SetActive(true);
                palancaActiva.SetActive(false);

                //animacion en reversa del objeto que mueve la palanaca
                cubo.SetBool("Activa", false);
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

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    cubo.SetBool("Activa", true);
        //    //cubo.Play("CuboEnMovimiento");
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    cubo.SetBool("Activa", false);
        //    //cubo.Play("CuboEnMovimiento");
        //}
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
