using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlayer : MonoBehaviour
{
    //Bool que nos dice si ya hay una bomba instanciada
    public static bool active_Bomb = false;
    //Bool para saber si la bomba se instancia en la base en lugar de frente al jugador
    public static bool is_on_base = false;
    //Bool para la detonación de la bomba
    public static bool explo = false;
    //GameObject del prefab de la bomba
    public GameObject prefab_Bomb;
    //Game object donde se guerda el prefab una vez instanciado
    public GameObject bombPrefab_Placeholder;
    //Vector 3 para saber dónde se va a instanciar la bomba
    private Vector3 player_bomb_instance_coordinates;

    void Start()
    {
        is_on_base = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && S_Player.ItemNumber == 2 && active_Bomb == true)
        {
            Bomb_Detonation();
        }

        if (Input.GetKeyDown(KeyCode.E) && S_Player.ItemNumber == 2 && active_Bomb == false && is_on_base == false)
        {
            Bomb_Activation();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bomb_Base")
        {
            if (Input.GetKeyDown(KeyCode.E) && S_Player.ItemNumber == 2 && active_Bomb == false)
            {
                Debug.Log("dad");

                is_on_base = true;
                Bomb_Base_Activation();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bomb_Base")
        {
            //is_on_base = false;
        }
    }

    void Bomb_Activation()
    {
        explo = false;
        active_Bomb = true;
        player_bomb_instance_coordinates = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 1.2f);
        Instantiate(prefab_Bomb, player_bomb_instance_coordinates, Quaternion.identity);
        bombPrefab_Placeholder = GameObject.Find("BombaPrefab(Clone)");
    }

    void Bomb_Base_Activation()
    {
        explo = false;
        active_Bomb = true;
    }

    void Bomb_Detonation()
    {
        explo = true;

        active_Bomb = false;
        is_on_base = false;

        Debug.Log("BOOOOM!!!");
        Destroy(bombPrefab_Placeholder);
    }
}
