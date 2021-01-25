using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per controlar el player 
    /// AUTOR:  Mathias Miranda
    /// DATA:   18/01/21
    /// VERSIÓ: 0.1
    /// CONTROL DE VERSIONS
    ///         0.1: Moviment de la nau amb tecles i fisiques
    /// ----------------------------------------------------------------------------------
    /// </summary>
    
    
public class ScrPlayer : MonoBehaviour
{
    [SerializeField] 
    float velocitat = 10f;

    //**********  Gestió Shot  ********
    [SerializeField]
    GameObject missil; // element a instancar. Arroseguem pregab!
    [SerializeField] 
    Transform cano; // d'on surt la bala 


    //**********  Cooldown  *********
    float cadencia = 0.3f; // dispara cada 5 decimes
    float crono = 0f; // temps de cadencia

    Vector2 movi = new Vector2();   //per calcular moviment
    Rigidbody2D rb;                 //per accedir al component ribidbody2D

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Damos valor a rb
    }

    // Update is called once per frame
    void Update()
    {
        movi.x = ETCInput.GetAxis("Horizontal") * velocitat;
        movi.y = ETCInput.GetAxis("Vertical") * velocitat;

        if (ETCInput.GetButtonDown("Shoot") && crono > cadencia) Dispara();
        crono += Time.deltaTime;

        if (ETCInput.GetButtonUp("Shoot")) crono = cadencia; // Permet disparar ràpid amb múltiples clicks
    }

    private void FixedUpdate()
    {
        rb.velocity = movi;  //Apliquem velocitat. No utilitzar Translate (son fisiques!)
    }

    void Dispara()
    {
        Instantiate(missil, cano.position, Quaternion.Euler(new Vector3(0, 0, 33)));
        Instantiate(missil, cano.position, cano.rotation);
        Instantiate(missil, cano.position, Quaternion.Euler(new Vector3(0, 0, -33)));
        crono = 0;
    }
}
