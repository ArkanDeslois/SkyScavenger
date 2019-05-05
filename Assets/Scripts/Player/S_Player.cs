using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    //COSAS DE ARKANNNNNNNNNNNNNNNNNNNNNNNNNNNNN!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
    public bool HasE_K = false;
    public GameObject E_K;
    public GameObject LockEK;
    public bool TieneEK;
    //public EnergyKeyLock EK;



    //La variable bool "MiBool" checa si está tocando la escalera para cambiar valores de z en y
    private bool Climb = false;

    //Rigidbody del player. sólo se utiliza para el salto, por ahora
    private Rigidbody player_RB;

    //Valor entero que multiplica el valor con el que se mueve el personaje
    public float velocidad_Mov;

    //Valor entero que multiplica el valor del salto
    public int salto;

    //Declaración del gameobject de la caja
    //public GameObject LaCaja;

    //Declaración de las Items del HUD
    public GameObject Item_Pico_HUD, Item2_Guante_HUD, Item3_Bomba_HUD, Item4_IceBeam_HUD;

    //Número que lleva cuentas de los items que tienes encima
    private int ItemCode;

    //Coordenadas del respawn, esto puede cambiar en un futuro si necesitamos tener varios respawns
    public Vector3 waterRespawn;

    //Número que lleva cuenta del item equipado actualmente
    //ItemNumber 0 = Nada
    //ItemNumber 1 = Pico
    //Itemumber 2 = Guantes
    //Itemumber 3 = Bomba
    //Itemumber 4 = IceBeam

    public static int ItemNumber;

    //Declaración del gameobject de la llave azul que se encuentra en la escena (esfera azul)
    public GameObject Item_Guantlets_esfera;

    //Declaración de los gameobjects de las puertas que se abren y cierran
    //public GameObject RedDoor, BlueDoor, GreenDoor;

    void Start()
    {
        player_RB = GetComponent<Rigidbody>();
        ItemCode = 4;
        ItemNumber = 1;
        Item_Pico_HUD.SetActive(true);
        Item2_Guante_HUD.SetActive(false);
        Item3_Bomba_HUD.SetActive(false);
        Item4_IceBeam_HUD.SetActive(false);
        E_K.SetActive(false);
        //GreenDoor.SetActive(true);
        //RedDoor.SetActive(true);
        //BlueDoor.SetActive(true);
    }

    void Update()
    {
        //Todo lo que involucra movimiento del player (Salto, caminar, escalar y ya...?)
        Movimiento();

        //Cambio y/o equpamiento de items. Tanto en el hud como en... el juego?
        ItemSwitch();




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

        //Muerte del personaje (Cae)
        if (other.tag == "Muerte")
        {
            this.transform.position = new Vector3(6, 1.7f, 1);
        }


        //Pregunta si está tocando el collider que le permite escalar
        if (other.tag == "Ladder")
        {
            Climb = true;
        }



        //Pregunta por el lado de la caja que el Player está tocando y la mueve
        //if (other.tag == "BFront")
        //{
        //    Debug.Log("Empujaría pa tras");
        // }

        // if (other.tag == "BBack")
        //{
        //     Debug.Log("Empujaría pa delante");
        // }

        // if (other.tag == "BRight")
        // {
        //    Debug.Log("Empujaría pa la left");
        // }

        // if (other.tag == "BLeft")
        // {
        //     Debug.Log("Empujaría pa la derecha");
        // }



        //Recoge y destruye la llave azul que está en la escena
        if (other.tag == "Item_G")
        {
            ItemCode++;
            Destroy(Item_Guantlets_esfera);
        }

        if (other.tag == "RedDoor" && ItemNumber == 1)
        {
            //RedDoor.SetActive(false);
        }
        if (other.tag == "GreenDoor" && ItemNumber == 2)
        {
            //GreenDoor.SetActive(false);
        }
        if (other.tag == "BlueDoor" && ItemNumber == 3)
        {
            //BlueDoor.SetActive(false);
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
            player_RB.useGravity = true;
            Climb = false;
        }

        if (other.tag == "RedDoor")
        {
            //RedDoor.SetActive(true);
        }
        if (other.tag == "GreenDoor")
        {
            //GreenDoor.SetActive(true);
        }
        if (other.tag == "BlueDoor")
        {
            //BlueDoor.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water_Respawn")
        {
            Debug.Log("muerte por agua");
            this.transform.position = waterRespawn;
        }
    }

    public void Movimiento()
    {

        //Condición de movimiento hacie enfrente y escalar
        if (Input.GetKey(KeyCode.W) && Climb == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocidad_Mov);
            //player_RB.AddForce(transform.forward * empuje);
        }
        else if (Input.GetKey(KeyCode.W) && Climb == true)
        {
            player_RB.useGravity = false;
            //transform.Translate(Vector3.forward * Time.deltaTime * empuje);
            transform.Translate(Vector3.up * Time.deltaTime * velocidad_Mov);
        }


        //El resto de las condiciones de movimiento
        float horizontalMov = Input.GetAxis("Horizontal") * velocidad_Mov;
        float verticalMov = Input.GetAxis("Vertical") * velocidad_Mov;
        player_RB.velocity = new Vector3(Input.GetAxis("Horizontal") * velocidad_Mov, player_RB.velocity.y, Input.GetAxis("Vertical") * velocidad_Mov);

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

            if (ItemNumber == 1)
            {
                Item_Pico_HUD.SetActive(true);
                Item2_Guante_HUD.SetActive(false);
                Item3_Bomba_HUD.SetActive(false);
                Item4_IceBeam_HUD.SetActive(false);
            }
            else if (ItemNumber == 2)
            {

                Item_Pico_HUD.SetActive(false);
                Item2_Guante_HUD.SetActive(true);
                Item3_Bomba_HUD.SetActive(false);
                Item4_IceBeam_HUD.SetActive(false);

            }
            else if (ItemNumber == 3)
            {
                Item_Pico_HUD.SetActive(false);
                Item2_Guante_HUD.SetActive(false);
                Item3_Bomba_HUD.SetActive(true);
                Item4_IceBeam_HUD.SetActive(false);
            }

            else if (ItemNumber == 4)
            {
                Item_Pico_HUD.SetActive(false);
                Item2_Guante_HUD.SetActive(false);
                Item3_Bomba_HUD.SetActive(false);
                Item4_IceBeam_HUD.SetActive(true);
            }
        }
    }

 
}