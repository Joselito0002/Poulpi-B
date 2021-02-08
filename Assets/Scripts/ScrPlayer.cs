using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per controlar el player 
    /// AUTOR:  Mathias Miranda
    /// DATA:   18/01/21
    /// VERSIÓ: 0.3
    /// CONTROL DE VERSIONS
    ///         0.1: Moviment de la nau amb tecles i fisiques
    ///         0.2: Crear trets de la nau
    ///         0.3: Crear 3 trets de canons
    /// ----------------------------------------------------------------------------------
    /// </summary>
    
    
public class ScrPlayer : MonoBehaviour
{
  
    [SerializeField] 
    float velocitat = 10f;
    Vector2 movi = new Vector2();   //per calcular moviment
    Rigidbody2D rb;                 //per accedir al component ribidbody2D
    AudioSource so;


    //**********  Gestió Shot  ********
    [SerializeField] GameObject missil; // element a instancar. Arroseguem pregab!
    [SerializeField] Transform [] canons; // d'on surt la bala 


    //**********  Cooldown  *********
    [SerializeField] float cadencia = 0.5f; // dispara cada 5 decimes
    float crono = 0f; // temps de cadencia
    float cronoPowerUp = 0f; 
    

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

        if (ETCInput.GetButton("Shoot") && crono > cadencia) Dispara();
        crono += Time.deltaTime;

        if (ETCInput.GetButtonUp("Shoot")) crono = cadencia; // Permet disparar ràpid amb múltiples clicks

        if (Input.GetKeyDown(KeyCode.T)) // Proto del tripe shoot
        {
            SetTripleShoot(true);
            cronoPowerUp = 5f;
        }

        if (cronoPowerUp > 0) cronoPowerUp -= Time.deltaTime; //descuenta el tiempo desde que le das a T
        else SetTripleShoot(false);  //Como no es más grande que 0, se desactiva

        so = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        rb.velocity = movi;  //Apliquem velocitat. No utilitzar Translate (son fisiques!)
    }

    void Dispara()
    {
            foreach(Transform cano in canons)
            if (cano.gameObject.activeSelf) Instantiate(missil, cano.position, cano.rotation);  // si les instancies estan visibles, dispararà, si no, no ho fa tampoc de manera predeterminada
            crono = 0;

        so.Play();
    }

    void SetTripleShoot(bool estat) //Fa activa les instancies, si no, no dispara 3
    {
        canons[0].gameObject.SetActive(estat);
        canons[2].gameObject.SetActive(estat);
    }

    void Destruccio() //Indica com es destrueix
    {
        Destroy(gameObject);
    }
}
