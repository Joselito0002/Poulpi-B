using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrShot : MonoBehaviour
{
    [SerializeField]
    float vel = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vel * Time.deltaTime, 0, 0);
    }
}
