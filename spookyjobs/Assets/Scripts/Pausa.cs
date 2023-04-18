using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject menuP;
    bool menuAbierto;
    // Start is called before the first frame update
    void Start()
    {
        menuAbierto = false;
        menuP.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && menuAbierto == false)
        {
            menuP.SetActive(true);
            Time.timeScale = 0f;
            menuAbierto = false;
        }
    }
    public void continuar()
    {
        menuP.SetActive(false);
        Time.timeScale = 1f;
    }
    public void salir()
    {
        menuP.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
