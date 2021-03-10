using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrNPCShot : MonoBehaviour
{
    [SerializeField] Transform cano;
    [SerializeField] GameObject projectil;
    [SerializeField] float cadenciaMin = 1, cadenciaMax = 3; // tiempo entre disparos
    float crono;
    [SerializeField] Renderer render;
    [SerializeField] bool rotar = false;  // determina si dispara amb angle
    public bool atacant = true;  // determina si està atacant

    void Start()
    {
        crono = Random.Range(cadenciaMin, cadenciaMax); // Preparem primer tret
    }

    // Update is called once per frame
    void Update()
    {
        if (render && ScrControlGame.EsVisibleDesde(render, Camera.main) && atacant)
        {
            crono -= Time.deltaTime;
            if (crono <= 0) Dispara();
        }
    }

    void Dispara()
    {
        GameObject b = Instantiate(projectil, cano.position, cano.rotation);
        if (rotar) b.transform.Rotate(0, 0, Random.Range(-10, 10)); // modifiquem trajectoria aleatoriament
        crono = Random.Range(cadenciaMin, cadenciaMax); // Següent shot
    }

}
