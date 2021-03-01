using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrScrollParallax : MonoBehaviour
{
    [SerializeField] float scrollspeed = 0f;


    void Update()
    {
        transform.Translate(scrollspeed * Time.deltaTime, 0, 0);   //Time.deltaTime para hacer independiente el juego del ordenador
    }
}
