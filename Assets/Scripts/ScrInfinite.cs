using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrInfinite : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        //la imagen mide 2048 pixels y hay 3
        transform.Translate(20.48f * 4, 0f, 0f);
    }
}
