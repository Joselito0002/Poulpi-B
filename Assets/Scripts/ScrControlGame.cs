using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrControlGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if (UNITY_EDITOR)
        //AudioListener.pause = true;  //solo se ejecuta cuando estamos en unity editor
#endif
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.M)) AudioListener.pause = !AudioListener.pause; //pasar de falso a true o true a falso
        
    }
    static public bool EsVisibleDesde(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}

