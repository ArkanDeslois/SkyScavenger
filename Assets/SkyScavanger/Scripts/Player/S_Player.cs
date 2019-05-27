using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    //COSAS DE ARKANNNNNNNNNNNNNNNNNNNNNNNNNNNNN!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //public bool HasE_K = false;
   //public GameObject E_K;
    //public GameObject LockEK;
    //public bool TieneEK;
    //public EnergyKeyLock EK;


    //La variable bool "MiBool" checa si está tocando la escalera para cambiar valores de z en y
    private bool Climb = false;

    //variables para saber si ya tiene alguna herramienta
    public bool hasPicaxe, hasFreeze, hasBomb, hasGuantes;

    //Array para almacenar el orden de los tools
    private string[] tools;

    //Valor entero que multiplica el valor con el que se mueve el personaje
    public float velocidad_Mov;

    //Coordenadas del respawn, esto puede cambiar en un futuro si necesitamos tener varios respawns
    public Vector3 waterRespawn;

    //Declaración de las Items del HUD
    public GameObject Pico_HUD, Guante_HUD, Bomba_HUD, IceBeam_HUD;

    //Bool para checar qué item cogió primero entre bomba y guante
    public bool secondToolCheckBombIsTrue;

    //Número que lleva cuentas de los items que tienes encima
    private int ItemCode = 0;

    //Número que lleva cuenta del item equipado actualmente
    //ItemNumber 0 = Nada
    //ItemNumber 1 = Pico
    //Itemumber 2 = Bomba/Guantes
    //Itemumber 3 = Freeze
    //Itemumber 4 = Guantes/Bomba
    public static int ItemNumber = 0;

    //Rigibody del player
    private Rigidbody player_RB;

    void Start()
    {
        player_RB = GetComponent<Rigidbody>();

        //Está apagando los íconos del HUD
        Pico_HUD.SetActive(false);
        Guante_HUD.SetActive(false);
        Bomba_HUD.SetActive(false);
        IceBeam_HUD.SetActive(false);


        //E_K.SetActive(false);
        //GreenDoor.SetActive(true);
        //RedDoor.SetActive(true);
        //BlueDoor.SetActive(true);
    }

    void Update()
    {
        //Todo lo que involucra movimiento del player (Salto, caminar, escalar y ya...?)
        Movimiento();

        //Cambio y/o equpamiento de items. Tanto en el hud como en... el juego?
        if(ItemNumber>0)
        ItemSwitch();

        if (hasBomb == true && hasGuantes == false)
        {
            secondToolCheckBombIsTrue = true;
        } else if (hasGuantes == true && hasBomb == false)
        {
            secondToolCheckBombIsTrue = false;
        }

        Debug.Log("Número de tools que ha conseguido: " + ItemCode);
        Debug.Log("Tool equipado actualmente: " + ItemNumber);

        //TODO ESTO LO HIZO ARKAN!!!!!!!!!!
        /* if (HasE_K == false && TieneEK == false)
         {
             E_K.SetActive(false);
         }
         if (TieneEK == true && HasE_K == false)
         {
             E_K.SetActive(true);

         }
         if (TieneEK == false && HasE_K == true)
         {
             E_K.SetActive(true);

         }*/
    }

    void OnTriggerStay(Collider other)
    {
        //Pregunta si está tocando el collider que le permite escalar
        if (other.tag == "Ladder")
        {
            Climb = true;
            player_RB.useGravity = false;
            //player_RB.constraints = RigidbodyConstraints.FreezePositionX;

        }

        //MIERDA DE ARKAN!!!!!!!!!!!!!!!!!!!!!!1 ALV!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /*if (other.tag == "EnergyKey" && Input.GetKey(KeyCode.P))
        {
          HasE_K = true;
          E_K.SetActive(true);
          other.gameObject.SetActive(false);
        }
        if (other.tag == "EnergyKey" && Input.GetKey(KeyCode.P))
        {
            TieneEK = true;
            E_K.SetActive(true);
            other.gameObject.SetActive(false);
        }
       if (EK.YaBajo == true && Input.GetKeyDown(KeyCode.P))
        {
            LockEK.SetActive(false);
            E_K.SetActive(true);
            TieneEK = true;
            HasE_K = true;
        }*/
    }

    void OnTriggerExit(Collider other)
    {
        //Checa una vez que el jugador sale del collider de la "escalera"
        if (other.tag == "Ladder")
        {
            //player_RB.useGravity = true;
            Climb = false;
            player_RB.useGravity = true;
            //player_RB.constraints = RigidbodyConstraints.None;
            //player_RB.constraints = RigidbodyConstraints.FreezeRotation;

        }
    }

    private void OnTriggerEnter(Collider other)
    {

      //Muerte al player cuando toca colliders de muerte de agua
      if (other.tag == "Water_Respawn")
      {
              Debug.Log("muerte por agua");
              this.transform.position = waterRespawn;
      }


      //Recoge y el pico obtenible en escena
      if (other.tag == "Pico_Obtenible")
      {
        ItemCode++;
        ItemNumber++;
            ////Soluciones chacas!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            //Pico_HUD.SetActive(true);
            Destroy(other.gameObject);
            hasPicaxe = true;

            Pico_HUD.SetActive(true);
            Guante_HUD.SetActive(false);
            Bomba_HUD.SetActive(false);
            IceBeam_HUD.SetActive(false);
        }

        //Recoge y destruye la bomba que está en la escena
        if (other.tag == "Bomba_Obtenible")
        {
            ItemCode++;
            ItemNumber++;
            //Soluciones chacas!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            //Pico_HUD.SetActive(true);
            Destroy(other.gameObject);
            hasBomb = true;

            Pico_HUD.SetActive(false);
            Guante_HUD.SetActive(false);
            Bomba_HUD.SetActive(true);
            IceBeam_HUD.SetActive(false);
        }

        //Recoge y el Guante obtenible en escena
        if (other.tag == "Guante_Obtenible")
        {
            ItemCode++;
            //ItemNumber++;
            ////Soluciones chacas!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            //Pico_HUD.SetActive(true);
            Destroy(other.gameObject);
            hasGuantes = true;


        }

        //Recoge y el freeze obtenible en escena
        if (other.tag == "Freeze_Obtenible")
        {
            ItemCode++;
            //ItemNumber++;
            ////Soluciones chacas!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            //Pico_HUD.SetActive(true);
            Destroy(other.gameObject);
            hasFreeze = true;
        }

    }

    public void Movimiento()
    {
        //Condición de movimiento hacie enfrente y escalar
        if (Input.GetKey(KeyCode.W) && Climb == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * velocidad_Mov);
            transform.Translate(Vector3.forward * Time.deltaTime * velocidad_Mov);
        }
    }

    public void ItemSwitch()
    {
        //Toogle entre las llaves que aparecen en el canvas, la llave que tienes equipada
        if (Input.GetKeyDown(KeyCode.E))
        {
            ItemNumber++;
            if (ItemNumber > ItemCode)
            {
                ItemNumber = 1;
            }
            //Pico
            if (ItemNumber == 1)
            {
                Pico_HUD.SetActive(true);
                Guante_HUD.SetActive(false);
                Bomba_HUD.SetActive(false);
                IceBeam_HUD.SetActive(false);
            }

            //Bomba
            if (ItemNumber == 2 && secondToolCheckBombIsTrue == true)
            {

                Pico_HUD.SetActive(false);
                Guante_HUD.SetActive(false);
                Bomba_HUD.SetActive(true);
                IceBeam_HUD.SetActive(false);
            }
            else if(ItemNumber == 2 && secondToolCheckBombIsTrue == false)
            {
                Pico_HUD.SetActive(false);
                Guante_HUD.SetActive(true);
                Bomba_HUD.SetActive(false);
                IceBeam_HUD.SetActive(false);
            }
            //Freeze
            if (ItemNumber == 3)
            {
                Pico_HUD.SetActive(false);
                Guante_HUD.SetActive(false);
                Bomba_HUD.SetActive(false);
                IceBeam_HUD.SetActive(true);
            }

            //guante
            if (ItemNumber == 4 && secondToolCheckBombIsTrue == true)
            {
                Pico_HUD.SetActive(false);
                Guante_HUD.SetActive(true);
                Bomba_HUD.SetActive(false);
                IceBeam_HUD.SetActive(false);
            }
            else if (ItemNumber == 4 && secondToolCheckBombIsTrue == false)
            {
                Pico_HUD.SetActive(false);
                Guante_HUD.SetActive(false);
                Bomba_HUD.SetActive(true);
                IceBeam_HUD.SetActive(false);
            }
        }
    }

 
}