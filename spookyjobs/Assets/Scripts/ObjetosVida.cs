using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosVida : MonoBehaviour
{
    public GameObject canvas;
    public bool objetoElegido;
    Vida vidapers;
    // Start is called before the first frame update
    void Start()
    {
        objetoElegido = false;
        canvas.SetActive(false);
        vidapers = FindObjectOfType<Vida>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cubo" && objetoElegido == false)
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
    public void regeneracion()
    {
        vidapers.MejoraVida = true;
        canvas.SetActive(false);
        objetoElegido = true;
    }
    public void corazonextra()
    {
        vidapers.mejoraCorazonExtra = true;
        canvas.SetActive(false);
        objetoElegido = true;
    }
    public void amasvmd()
    {

    }
    public void amenosvmd()
    {

    }
    public void sacrificio()
    {
        vidapers.mejoraMedCorCriticoused = true;
        canvas.SetActive(false);
        objetoElegido = true;
    }
}
