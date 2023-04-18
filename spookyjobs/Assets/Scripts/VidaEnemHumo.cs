using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemHumo : MonoBehaviour
{
    float tiempoDeVida;
    // Start is called before the first frame update
    void Start()
    {
        tiempoDeVida = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDeVida -= Time.deltaTime;
        if(tiempoDeVida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
