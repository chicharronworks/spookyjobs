using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenuPrincipal : MonoBehaviour
{
    public GameObject canvasControles;
    public GameObject canvasOpciones;
    [SerializeField] AudioSource audio1;
    [SerializeField] AudioClip botonencima;
    [SerializeField] AudioClip audioClick;
    private void Start()
    {
        canvasControles.SetActive(false);
        canvasOpciones.SetActive(false);
    }
    public void botonJugar()
    {
        SceneManager.LoadScene("SampleScene");
        audio1.PlayOneShot(audioClick);
    }
    public void botonSalir()
    {
        Application.Quit();
        audio1.PlayOneShot(audioClick);
    }
    public void botonControles()
    {
        canvasControles.SetActive(true);
        audio1.PlayOneShot(audioClick);
    }
    public void botonVolver()
    {
        canvasControles.SetActive(false);
        audio1.PlayOneShot(audioClick);
    }
    public void botonOpciones()
    {
        canvasOpciones.SetActive(true);
        audio1.PlayOneShot(audioClick);
    }
    public void botonVolverOpciones()
    {
        canvasOpciones.SetActive(false);
        audio1.PlayOneShot(audioClick);
    }
    public void SonidoMouseEncima()
    {
        audio1.PlayOneShot(botonencima);
    }
}
