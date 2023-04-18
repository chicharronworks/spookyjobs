using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindeSala : MonoBehaviour
{
    public GameObject puertaCerrada;
    public GameObject puertaAbierta;
    GameObject puertaA;
    Movimiento mov;
    public bool pabierta;
    public GameObject salas;
    public GameObject salas2;
    public GameObject salas3;
    public GameObject sala1;
    public bool salaCompletada;
    public GameObject pers;
    public GameObject spawn;
    public AudioSource audioSourcePuerta;
    public AudioClip puertaDes;
    public CameraFade fadeCam;
    float contadorComienzo = 0f;
    int randomsala;
    public GameObject tadaefecto;
    GameObject tada;
    int numerodeSalas = 0;
    // Start is called before the first frame update
    void Start()
    {
        mov = FindObjectOfType<Movimiento>();
        pabierta = false;
        sala1 = Instantiate(salas, salas.transform.position, salas.transform.rotation);
        numerodeSalas = 1;
        salaCompletada = false;
        fadeCam = FindObjectOfType<CameraFade>();
        fadeCam.Fade();
    }

    // Update is called once per frame
    void Update()
    {
        contadorComienzo += Time.deltaTime;
        puertaCerrada = GameObject.FindGameObjectWithTag("puerta");
        if (!GameObject.FindGameObjectWithTag("Enemigo")&&!GameObject.FindGameObjectWithTag("SiguienteSala")&&pabierta == false&&contadorComienzo > 0.5f)
        {
            finalizarSala();
        }
        if (mov.finSala == true)
        {
            Destroy(puertaA);
            mov.finSala = false;
            salaCompletada = true;
        }
        if (salaCompletada == true)
        {
            instanciarSiguienteSala();
        }
    }
    public void finalizarSala()
    {
        Destroy(puertaCerrada);
        tada = Instantiate(tadaefecto, tadaefecto.transform.position, tadaefecto.transform.rotation);
        Destroy(tada, 0.7f);
        puertaA = Instantiate(puertaAbierta, puertaAbierta.transform.position, puertaAbierta.transform.rotation);
        audioSourcePuerta.PlayOneShot(puertaDes);
        pabierta = true;
    }
    public void instanciarSiguienteSala()
    {
        salaCompletada = false;
        fadeCam.Fade();
        Destroy(sala1);
        numerodeSalas = 0;
        if(numerodeSalas == 0)
        {
            instanciarSala();
            numerodeSalas = 1;
        }
        
    }
    public void instanciarSala()
    {
        randomsala = Random.Range(1, 4);
        switch (randomsala)
        {
            case 1:
                sala1 = Instantiate(salas, salas.transform.position, salas.transform.rotation);
                break;
            case 2:
                sala1 = Instantiate(salas2, salas2.transform.position, salas2.transform.rotation);
                break;
            case 3:
                sala1 = Instantiate(salas3, salas3.transform.position, salas3.transform.rotation);
                break;
        }
        sala1 = Instantiate(salas, salas.transform.position, salas.transform.rotation);
        contadorComienzo = 0f;
        pabierta = false;
        pers.transform.position = spawn.transform.position;
    }
}
