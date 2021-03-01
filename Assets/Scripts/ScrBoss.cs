using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBoss : MonoBehaviour
{

    [SerializeField] GameObject explosio;
    void Destruccio()
    {
        Instantiate(explosio, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
