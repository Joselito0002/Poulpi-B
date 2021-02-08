using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar el NPC 
/// AUTOR:  Mathias Miranda
/// DATA:   01/02/21
/// VERSIÓ: 0.1
/// CONTROL DE VERSIONS
///         0.1: Moviment NPC
/// ----------------------------------------------------------------------------------
/// </summary>


public class ScrPoulpi : MonoBehaviour
{
    [SerializeField] float velX = -5f;
    [SerializeField] GameObject explosio; //per la destruccio
    Vector2 moviment = new Vector2();
    
    Rigidbody2D rb;

    // *********************** Variables de moviment **************************
    [SerializeField]
    int tipusMoviment = 1;
    float velY;
    float desfase;
    [SerializeField] float elast;
    GameObject player;
    const int QUANTS_MOVIMENTS = 5;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velY = Random.Range(-2f, 2f);  

        desfase = Random.Range(0f, 360f); 

        player = GameObject.FindGameObjectWithTag("Player"); //apunta la nau
        if (tipusMoviment == 0) tipusMoviment = Random.Range(1, QUANTS_MOVIMENTS + 1); // el +1 es porque el random range si es con ints, pilla hasta el ultimo del rango -1
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculaMoviment(tipusMoviment);
        rb.velocity = moviment;       
    }

    void CalculaMoviment(int tipus)
    {
        switch (tipus)
        {
            case 1: //moviment a velocitat X
                moviment.x = velX;
                moviment.y = 0f;
                break;
            case 2: 
                moviment.x = velX/2;
                moviment.y = 0f;
                break;
            case 3:
                moviment.x = velX;
                moviment.y = velY;
                break;
            case 4:
                float amplitut = 4, frequencia = 3;
                moviment.x = velX;       
                moviment.y = Mathf.Sin(Time.time * frequencia + desfase) * amplitut; //manera sinusoidal
                break;
            case 5:
                    moviment.x = -1;
                    if (player)
                        moviment.y = player.transform.position.y - transform.position.y / elast;
                    else 
                        moviment.y = 0;
                break;
        }

        
    }
    void Destruccio() //Indica com es destrueix
    {
        Instantiate(explosio, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
