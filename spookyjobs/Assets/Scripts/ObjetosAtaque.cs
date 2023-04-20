using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosAtaque : MonoBehaviour
{
    public GameObject canvas;
    InstanciarBomba bomba;
    MejoraCritico critico;
    public bool objetoelegido;
    MejoraVeneno mejoraveneno;
    MejoraAtaque mejoraataque;
    // Start is called before the first frame update
    void Start()
    {
        objetoelegido = false;
        canvas.SetActive(false);
        bomba = FindObjectOfType<InstanciarBomba>();
        critico = FindObjectOfType<MejoraCritico>();
        mejoraveneno = FindObjectOfType<MejoraVeneno>();
        mejoraataque = FindObjectOfType<MejoraAtaque>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cubo" && objetoelegido == false)
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cubo")
        {
            canvas.SetActive(false);
        }
    }
    public void mejorabomba()
    {
        if(objetoelegido == false)
        {
            bomba.ObjetoBomba = true;
            objetoelegido = true;
            canvas.SetActive(false);
        }
    }
    public void AumentoAtaque()
    {
        if (objetoelegido == false)
        {
            mejoraataque.mejoraactiva = true;
            objetoelegido = true;
            canvas.SetActive(false);
        }
    }
    public void Veneno()
    {
        if (objetoelegido == false)
        {
            mejoraveneno.mejoraveneno = true;
            objetoelegido = true;
            canvas.SetActive(false);
        }
    }
    public void Critico()
    {
        if (objetoelegido == false)
        {
            critico.mejoraActiva = true;
            objetoelegido = true;
            canvas.SetActive(false);
        }
    }
}
