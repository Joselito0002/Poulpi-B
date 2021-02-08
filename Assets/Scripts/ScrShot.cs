using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar els trets 
/// AUTOR:  Mathias Miranda
/// DATA:   18/01/21
/// VERSIÓ: 0.1
/// CONTROL DE VERSIONS
///         0.1: Moviment de la nau amb tecles i fisiques
///         0.2: Crear trets de la nau
///         0.3: Crear 3 trets de canons
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrShot : MonoBehaviour
{
    [SerializeField] float vel = 20f;
    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.Translate(vel * Time.deltaTime, 0, 0);
    }
    void Destruccio() //Indica com es destrueix
    {
        Destroy(gameObject);
    }

}
