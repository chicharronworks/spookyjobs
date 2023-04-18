using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenuPrincipal : MonoBehaviour
{
    public GameObject canvasControles;
    public GameObject canvasOpciones;
    private void Start()
    {
        canvasControles.SetActive(false);
        canvasOpciones.SetActive(false);
    }
    public void botonJugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void botonSalir()
    {
        Application.Quit();
    }
    public void botonControles()
    {
        canvasControles.SetActive(true);
    }
    public void botonVolver()
    {
        canvasControles.SetActive(false);
    }
    public void botonOpciones()
    {
        canvasOpciones.SetActive(true);
    }
    public void botonVolverOpciones()
    {
        canvasOpciones.SetActive(false);
    }
}
