using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSalaBoss : MonoBehaviour
{
    ControlDeSalas gestordesalas;
    [SerializeField] GameObject ControladorDeSalas;
    [SerializeField] GameObject jugador;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject prefabSalaBoss;
    GameObject sala;
    bool salaInstanciada;
    // Start is called before the first frame update
    void Start()
    {
        salaInstanciada = false;
        gestordesalas = FindObjectOfType<ControlDeSalas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gestordesalas.contadorDeSalasCompletadas >= 10 && salaInstanciada == false)
        {
            ControladorDeSalas.SetActive(false);
            InstanciarSalaFinal();
            salaInstanciada = true;
        }
    }
    void InstanciarSalaFinal()
    {
        sala = Instantiate(prefabSalaBoss, prefabSalaBoss.transform.position, prefabSalaBoss.transform.rotation);
        jugador.transform.position = spawn.transform.position;
    }
}
