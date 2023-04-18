using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraCritico : MonoBehaviour
{
    [SerializeField] bool mejoraActiva;
    bool mejoraAplicada;
    SistemaDeCritico critico;
    // Start is called before the first frame update
    void Start()
    {
        mejoraActiva = false;
        mejoraAplicada = false;
        critico = FindObjectOfType<SistemaDeCritico>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mejoraActiva == true && mejoraAplicada == false)
        {
            mejoraAplicada = true;
            critico.porcentajeCritico += 20;
        }
    }
}
