using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBoss : MonoBehaviour
{

    [SerializeField] GameObject explosio;

    [SerializeField] Renderer r; //associar render del cos
    Collider2D col;
    [SerializeField] float velocitat;
    bool moviment = true;

    bool detectaPlayer = false;
    [SerializeField] LayerMask filtreCapes;

    Animator ani;

    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (ScrControlGame.EsVisibleDesde(r, Camera.main)) col.enabled = true;
        if (moviment) transform.Translate(velocitat * Time.deltaTime, 0, 0);
    }

    void Destruccio()
    {
        Instantiate(explosio, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float radiDeteccio = 20;
        detectaPlayer = Physics2D.OverlapCircle(transform.position, radiDeteccio, filtreCapes);
        if (detectaPlayer)
        {
            moviment = false;
            ani.SetBool("player_detectat", true);
            //GetComponentInParent<ScrNPCShot>().atacant = true;
        }
    }
}
