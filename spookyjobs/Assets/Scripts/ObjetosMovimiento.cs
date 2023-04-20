using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosMovimiento : MonoBehaviour
{
    public GameObject canvas;
    Movimiento mov;
    LanzarEsferaAstral estelaAstral;
    public bool objetoElegido;
    // Start is called before the first frame update
    void Start()
    {
        objetoElegido = false;
        canvas.SetActive(false);
        mov = FindObjectOfType<Movimiento>();
        estelaAstral = FindObjectOfType<LanzarEsferaAstral>();
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
    public void mejoraDash()
    {
        mov.mejoraDash = true;
        canvas.SetActive(false);
        objetoElegido = true;
    }
    public void mejoraAstral()
    {
        estelaAstral.MejoraAstral = true;
        canvas.SetActive(false);
        objetoElegido = true;
    }
}
