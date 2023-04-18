using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDePrimerasSalas : MonoBehaviour
{
    public GameObject gestorDeSalas;
    public bool finEleccion;
    public GameObject salaDeArmas;
    public GameObject pers;
    public GameObject spawn;
    public bool fine;
    // Start is called before the first frame update
    void Start()
    {
        gestorDeSalas.SetActive(false);
        finEleccion = false;
        fine = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(finEleccion == true)
        {
            pers.transform.position = spawn.transform.position;
            salaDeArmas.SetActive(false);
            gestorDeSalas.SetActive(true);
            finEleccion = false;
        }
        if(!GameObject.FindGameObjectWithTag("SelecArma")&&fine == false)
        {
            fine = true;
            finalizarSalaArmas();
        }
    }
    public void finalizarSalaArmas()
    {
        finEleccion = true;
    }
}
