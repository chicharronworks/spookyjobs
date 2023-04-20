using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosDefensa : MonoBehaviour
{
    public GameObject canvas;
    public bool objetoElegido;
    MejoraMinion mejorademinion;
    MejoraEscudo mejoradeescudo;
    Vida vidapers;
    // Start is called before the first frame update
    void Start()
    {
        objetoElegido = false;
        canvas.SetActive(false);
        mejorademinion = FindObjectOfType<MejoraMinion>();
        mejoradeescudo = FindObjectOfType<MejoraEscudo>();
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
    public void mejoraMinion()
    {
        mejorademinion.mejoraActiva = true;
        objetoElegido = true;
        canvas.SetActive(false);
    }
    public void mejoraEscudo()
    {
        mejoradeescudo.escudoactivo = true;
        objetoElegido = true;
        canvas.SetActive(false);
    }
    public void mejoraPinchos()
    {
        vidapers.mejoraDefensa = true;
        objetoElegido = true;
        canvas.SetActive(false);
    }
    public void mejoraDef()
    {
        vidapers.Mejorapinchos = true;
        objetoElegido = true;
        canvas.SetActive(false);
    }

}
