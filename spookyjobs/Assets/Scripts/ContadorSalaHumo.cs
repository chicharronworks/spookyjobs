using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorSalaHumo : MonoBehaviour
{
    [SerializeField] TMP_Text textoTiempo;
    float contadorSala;
    int contador;
    // Start is called before the first frame update
    void Start()
    {
        contadorSala = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        contadorSala -= Time.deltaTime;
        contador = (int)contadorSala;
        if(contador>=10)
        {
            textoTiempo.text = ("0:" + contador.ToString());
        }
        if(contador<10)
        {
            textoTiempo.text = ("0:0" + contador.ToString());
        }
        if(contadorSala<= 0) { contadorSala = 0f; }
    }
}
