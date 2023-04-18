using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMinion : MonoBehaviour
{
    float tiempoVida;
    // Start is called before the first frame update
    void Start()
    {
        tiempoVida = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoVida -= Time.deltaTime;
        if(tiempoVida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
