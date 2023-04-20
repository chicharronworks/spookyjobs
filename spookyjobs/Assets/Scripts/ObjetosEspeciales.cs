using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosEspeciales : MonoBehaviour
{
    public GameObject canvas;
    MejoraMonedas mejorademonedas;
    public bool ObjetoElegido;
    // Start is called before the first frame update
    void Start()
    {
        ObjetoElegido = false;
        canvas.SetActive(false);
        mejorademonedas = FindObjectOfType<MejoraMonedas>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cubo" && ObjetoElegido == false)
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
    public void elegirMejoraMonedas()
    {
        mejorademonedas.MasDosMonedas = true;
        ObjetoElegido = true;
        canvas.SetActive(false);
    }
}
