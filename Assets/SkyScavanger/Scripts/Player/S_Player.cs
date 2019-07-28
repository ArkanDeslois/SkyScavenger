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
    public Vector3 respawnAfterDeath;

    //HP del jugador
    public int hp;

    //Hp máxima del jugador
    public int hpLimit;

    //NOMBRES TEMPORALES!!!! Tipos de recursos y su cuenta
    public int recurso_jade;
    public int recurso_ruby;
    public int recurso_sapphire;

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

    //UI de los upgrades que el jugador puede conseguir
    public GameObject upgradeUI;

    //Indicadores si el jugador ya consiguío los upgrades de la tienda. 
    public static bool hasUp1, hasUp2, hasUp3;

    //UI corazoes
    public GameObject heart1, heart2, heart3;

    void Start()
    {
        player_RB = GetComponent<Rigidbody>();

        //Está apagando los íconos del HUD y UI
        Pico_HUD.SetActive(false);
        Guante_HUD.SetActive(false);
        Bomba_HUD.SetActive(false);
        IceBeam_HUD.SetActive(false);
        upgradeUI.SetActive(false);

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

            //El jugador muere?
            if (hp > hpLimit)
            {
                hp = hpLimit;
            }
            else if (hp <= 0)
            {
                PlayerisDead();
            }

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

        //Recoge y el pico obtenible en escena
        if (other.tag == "Pico_Obtenible" && Input.GetKeyDown(KeyCode.F))
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
        if (other.tag == "Bomba_Obtenible" && Input.GetKeyDown(KeyCode.F))
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
        if (other.tag == "Guante_Obtenible" && Input.GetKeyDown(KeyCode.F))
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

        //Dejar tus recursos en el cofre
        if (other.tag == "ResourceChest")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                ResourceChest.chest_recurso_Jade += recurso_jade;
                recurso_jade = 0;
                ResourceChest.chest_recurso_Ruby += recurso_ruby;
                recurso_ruby = 0;
                ResourceChest.chest_recurso_Sapphire += recurso_sapphire;
                recurso_sapphire = 0;
            }
        }

        //Cambio de recursos
        if(other.tag == "UpgradeSpot")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Upgrades();
            }
        }
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
      //Dano al player cuando toca colliders de muerte de agua y transform al cp
      if (other.tag == "Death_Respawn")
      {
              this.transform.position = respawnAfterDeath;
              PlayerTookDamage();
              
      }

        //Dano al player cuando toca la explosión de una bomba
        if (other.tag == "Bomb_Explotion")
        {
            PlayerTookDamage();
        }

        //Dano al player cuando toca la explosión de un enemigo
        if (other.tag == "Enemy")
        {
            PlayerTookDamage();
        }

        //Guardado de posición del úktimo checkpoint que tocó
        if (other.tag == "CheckPoint1")
        {
            respawnAfterDeath = other.gameObject.transform.position;
        }

        //Obtención de algún tipo de recurso
        if (other.tag == "Recurso_Jade")
        {
            Recursos(1);
            Destroy(other.gameObject);
        }
        if (other.tag == "Recurso_Ruby")
        {
            Recursos(2);
            Destroy(other.gameObject);
        }
        if (other.tag == "Recurso_Sapphire")
        {
            Recursos(3);
            Destroy(other.gameObject);
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
        if (Input.GetKeyDown(KeyCode.Q))
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

    public void PlayerisDead()
    {
        Debug.Log("He ded bro");
        recurso_jade = 0;
        recurso_ruby = 0;
        recurso_sapphire = 0;
    }

    public void Recursos(int tipoRecurso)
    {
        if(tipoRecurso == 1)
        {
            recurso_jade++;
        }
        else if (tipoRecurso == 2)
        {
            recurso_ruby++;
        }
        else if (tipoRecurso == 3)
        {
            recurso_sapphire++;
        }
    }

    public void Upgrades()
    {
        upgradeUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayerTookDamage()
    {
        if (hp > 0)
        {
            hp--;

            if (hp == 2)
            {
                heart3.SetActive(false);
                heart2.SetActive(true);
                heart1.SetActive(true);
            } else if(hp == 1)
            {
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(true);
            } else if(hp == 0)
            {
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(false);
            }
        } 
    }

}