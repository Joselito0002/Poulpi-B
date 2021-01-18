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
        
    }
}
