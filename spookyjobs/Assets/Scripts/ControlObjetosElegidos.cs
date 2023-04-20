using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjetosElegidos : MonoBehaviour
{
    ObjetosAtaque oa;
    ObjetosDefensa od;
    ObjetosEspeciales oe;
    ObjetosMovimiento om;
    ObjetosVida ov;
    bool eleccionTerminada;
    // Start is called before the first frame update
    void Start()
    {
        eleccionTerminada = false;
        oa = FindObjectOfType<ObjetosAtaque>();
        od = FindObjectOfType<ObjetosDefensa>();
        oe = FindObjectOfType<ObjetosEspeciales>();
        om = FindObjectOfType<ObjetosMovimiento>();
        ov = FindObjectOfType<ObjetosVida>();
    }

    // Update is called once per frame
    void Update()
    {
        if(oa.objetoelegido == true && od.objetoElegido == true && oe.ObjetoElegido == true && om.objetoElegido == true && ov.objetoElegido == true)
        {
            eleccionTerminada = true;
        }
        if(eleccionTerminada == true)
        {
            gameObject.SetActive(false);
        }
    }
}
