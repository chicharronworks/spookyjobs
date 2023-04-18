using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraEscudo : MonoBehaviour
{
    [SerializeField] GameObject escudo;
    public bool escudoactivo;
    bool destruido;
    float contadorRegeneracionEscudo;
    // Start is called before the first frame update
    void Start()
    {
        contadorRegeneracionEscudo = 10f;
        escudoactivo = false;
        destruido = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(escudoactivo == true)
        {
            escudo.SetActive(true);
        }
        if (escudoactivo == false)
        {
            escudo.SetActive(false);
        }
        if(destruido == true)
        {
            contadorRegeneracionEscudo -= Time.deltaTime;
            if(contadorRegeneracionEscudo <= 0)
            {
                destruido = false;
                regenerarEscudo();
                contadorRegeneracionEscudo = 10f;
            }
        }
    }
    public void destruirEscudo()
    {
        escudoactivo = false;
        destruido = true;
    }
    public void regenerarEscudo()
    {
        escudoactivo = true;
    }
}
