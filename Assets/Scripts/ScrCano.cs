using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCano : MonoBehaviour
{

    [SerializeField] GameObject apuntar; //objecte al que apuntem
    

    // Update is called once per frame
    void Update()
    {
        float velocitat = 7; //gira suaument 2 segons, a valors més grans, segueix més ràpid
        if (apuntar)
        {
            Vector3 offset = apuntar.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, offset);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation * Quaternion.Euler(0, 0, 270), velocitat * Time.deltaTime); //(canvi)
        }
    }
}
