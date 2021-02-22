using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per destruir el player, npc i trets segons X variables. 
/// AUTOR:  Mathias Miranda
/// DATA:   08/02/21
/// VERSIÓ: 0.1
/// CONTROL DE VERSIONS
///         0.1: Creem les variables que defineixen la vida abans del destroy
///       
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrCollision : MonoBehaviour
{
    [SerializeField]
    float vitality = 2f;

    [SerializeField] AudioClip tocat, enfonsat; // Inicialitzem en cada prefab

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool impacte = false;


        //print(transform.name + "vs" + collision.name); // per testejar collisions detectades
        ScrDamage scrD = collision.GetComponent<ScrDamage>(); //intentem llegir el script damage

        if (scrD) // si en té, es un objecte que treu vida. calculem
        {
            if (tag == "Player" && scrD.damagePlayer > 0) // soc el player i l'objecte em treu vida
            {
                vitality -= scrD.damagePlayer;
                impacte = true;
            }
            else if (tag != "Player" && scrD.damageNPC > 0) //soc npc i l'bjecte em treu vida
            {
                vitality -= scrD.damageNPC;
                impacte = true;
            }

            if (impacte)
            {
                if (vitality <= 0 && enfonsat)  //si enfonsat está asignado se ejecuta, si no, no 
                    AudioSource.PlayClipAtPoint(enfonsat, Camera.main.transform.position);
                if (vitality > 0 && tocat)   //lo mismo pero con tocat
                    AudioSource.PlayClipAtPoint(tocat, Camera.main.transform.position);
            }


            if (collision.tag == "shot" && impacte) collision.SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);  //si la colision es amb un projectil, es destrueix el "&& impacte" sirve para esquivar a los aliados

            if (vitality <= 0) SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver); //si no em queda vida, em destrueixo

        }


    }

}
