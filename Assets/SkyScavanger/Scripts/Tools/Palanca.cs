using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{

    //Bool para saber si está activada o desactivada la palanaca
    public bool activa = false, isOnLever;

    //Declaración de Animators
    public Animator objetivo;
    public Animator lever;

    void Start()
    {
        //Se prende y apaga la bandera para avisarnos si la palanca está activa... En el start está desactivada
        isOnLever = false;

        //Se buscan los componentes de los animators
        Animator objetivo = gameObject.GetComponent<Animator>();
        Animator lever = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log("isonlever: " + isOnLever);

        if (isOnLever == true && Input.GetKeyDown(KeyCode.Space))
        {
            //Si está desactivada entonces pasa a verdadera
            if (activa == false)
            {
                //Cambio de estado del bool
                activa = true;

                //Cambio de "animación" de la palanca
                lever.SetBool("Activacion", true);

                //animacion del objeto que mueve la palanaca
                objetivo.SetBool("Activa", true);
            }
            else
            {
                //Cambio de estado del bool
                activa = false;

                //Cambio de "animación" de la palanca
                lever.SetBool("Activacion", false);

                //animacion en reversa del objeto que mueve la palanaca
                objetivo.SetBool("Activa", false);
            }
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
