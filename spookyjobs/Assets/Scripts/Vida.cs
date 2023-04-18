using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vida;
    public GameObject corazon1;
    public GameObject medioCorazon1;
    public GameObject corazon2;
    public GameObject medioCorazon2;
    public GameObject corazon3;
    public GameObject medioCorazon3;
    bool ataque;
    public GameObject spawn;
    public shakeCamara shakeCamara;
    Rigidbody rb;
    public int fuerzaempuje;
    public bool MejoraVida;
    public bool Mejorapinchos;
    public float cooldownRegeneracion;
    public bool mejoraDefensa;
    public bool mejoraMedCorCritico;
    SistemaDeCritico sc;
    int critico;
    int critico1;
    int contadorcritico;
    bool mejoraMedCorCriticoused;
    MejoraEscudo mejoraescudo;//Mejora escudo
    [SerializeField] bool mejoraCorazonExtra; //Mejora corazón extra
    bool comienzoPartida; //Mejora corazón extra
    [SerializeField] GameObject corazon4;//Mejora corazón extra
    [SerializeField] GameObject medioCorazon4;//Mejora corazón extra
    // Start is called before the first frame update
    void Start()
    {
        ataque = false;
        vida = 3f;
        corazon1.SetActive(true);
        corazon2.SetActive(true);
        corazon3.SetActive(true);
        medioCorazon1.SetActive(false);
        medioCorazon2.SetActive(false);
        medioCorazon3.SetActive(false);
        spawn = GameObject.FindGameObjectWithTag("SpawnP");
        shakeCamara = FindObjectOfType<shakeCamara>();
        rb = GetComponent<Rigidbody>();
        MejoraVida = false;
        Mejorapinchos = false;
        mejoraDefensa = false;
        mejoraMedCorCritico = false;
        sc = GameObject.Find("GestionDePrimerasSalas").GetComponent<SistemaDeCritico>();
        contadorcritico = 0;
        critico1 = sc.porcentajeCritico;
        mejoraMedCorCriticoused = false;
        mejoraescudo = FindObjectOfType<MejoraEscudo>();//Mejora escudo
        mejoraCorazonExtra = false; //Mejora corazón extra
    }

    // Update is called once per frame
    void Update()
    {
        if (mejoraCorazonExtra == true && comienzoPartida == true) //Mejora corazón extra
        {
            vida = 4;
            comienzoPartida = false;
        }
        if (mejoraCorazonExtra == false) //Mejora corazón extra
        {
            corazon4.SetActive(false);
            medioCorazon4.SetActive(false);
        }
        if (mejoraMedCorCritico)
        {
            if (vida >= 3)
            {
                vida = 2.5f;
            }
            if (contadorcritico == 0) {
                sc.porcentajeCritico += 5;
                critico = sc.porcentajeCritico;
                contadorcritico++; 
            }
            if (critico != sc.porcentajeCritico)
            {
                critico1 = sc.porcentajeCritico;
                contadorcritico = 0;
            }
            mejoraMedCorCriticoused = true;
        }
        else
        {
            if (mejoraMedCorCriticoused)
            {
                sc.porcentajeCritico = critico1;
                mejoraMedCorCriticoused = false;
            }
        }
        if (MejoraVida)
        {
            
            if (cooldownRegeneracion <= 0)
            {
                MejoraRegeneracionVida();
            }
            else
            {
                cooldownRegeneracion -= Time.deltaTime;
            }
        }

        if (vida == 4) //Mejora corazón extra
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
            medioCorazon1.SetActive(false);
            medioCorazon2.SetActive(false);
            medioCorazon3.SetActive(false);
            corazon4.SetActive(true);
            medioCorazon4.SetActive(false);
        }
        if (vida == 3.5) //Mejora corazón extra
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
            medioCorazon1.SetActive(false);
            medioCorazon2.SetActive(false);
            medioCorazon3.SetActive(false);
            corazon4.SetActive(false);
            medioCorazon4.SetActive(true);
        }
        if (vida == 3)
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
            medioCorazon1.SetActive(false);
            medioCorazon2.SetActive(false);
            medioCorazon3.SetActive(false);
            corazon4.SetActive(false); //Mejora corazón extra
            medioCorazon4.SetActive(false); //Mejora corazón extra
        }
        if (vida == 2.5)
        {
            corazon3.SetActive(false);
            medioCorazon3.SetActive(true);
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon4.SetActive(false); //Mejora corazón extra
            medioCorazon4.SetActive(false); //Mejora corazón extra
        }
        if (vida == 2)
        {
            corazon3.SetActive(false);
            medioCorazon3.SetActive(false);
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon4.SetActive(false); //Mejora corazón extra
            medioCorazon4.SetActive(false); //Mejora corazón extra
        }
        if (vida == 1.5)
        {
            corazon3.SetActive(false);
            medioCorazon3.SetActive(false);
            corazon2.SetActive(false);
            medioCorazon2.SetActive(true);
            corazon1.SetActive(true);
            corazon4.SetActive(false); //Mejora corazón extra
            medioCorazon4.SetActive(false); //Mejora corazón extra
        }
        if (vida == 1)
        {
            corazon3.SetActive(false);
            medioCorazon3.SetActive(false);
            corazon2.SetActive(false);
            medioCorazon2.SetActive(false);
            corazon1.SetActive(true);
            corazon4.SetActive(false); //Mejora corazón extra
            medioCorazon4.SetActive(false); //Mejora corazón extra
        }
        if (vida == 0.5)
        {
            corazon3.SetActive(false);
            medioCorazon3.SetActive(false);
            corazon2.SetActive(false);
            medioCorazon2.SetActive(false);
            corazon1.SetActive(false);
            medioCorazon1.SetActive(true);
            corazon4.SetActive(false); //Mejora corazón extra
            medioCorazon4.SetActive(false); //Mejora corazón extra
        }
        if (vida <= 0)
        {
            corazon3.SetActive(false);
            medioCorazon3.SetActive(false);
            corazon2.SetActive(false);
            medioCorazon2.SetActive(false);
            corazon1.SetActive(false);
            medioCorazon1.SetActive(false);
            corazon4.SetActive(false); //Mejora corazón extra
            medioCorazon4.SetActive(false); //Mejora corazón extra
            transform.position = spawn.transform.position;
            vida = 3;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Enemigo")&&ataque == false && mejoraescudo.escudoactivo == false)
        {
            if (mejoraDefensa) {
                vida -= 0.5f/2f;
            }
            else {
                vida -= 0.5f;
            }
            
            ataque = true;
            StartCoroutine(shakeCamara.Shake());
            Vector3 direccion = collision.transform.position - transform.position;
            rb.AddForce(direccion * 15, ForceMode.Impulse);
            cooldownRegeneracion = 10f;
            if (Mejorapinchos)
            {
                collision.gameObject.GetComponent<VidaEnemigo>().contadorImpactosPicnchos++;
            }
        }
        if (collision.gameObject.tag == ("Enemigo") && ataque == false && mejoraescudo.escudoactivo == true)
        {
            if (mejoraDefensa)
            {
                vida -= 0f;
            }
            else
            {
                vida -= 0f;
            }

            ataque = true;
            StartCoroutine(shakeCamara.Shake());
            Vector3 direccion = collision.transform.position - transform.position;
            rb.AddForce(direccion * 15, ForceMode.Impulse);
            cooldownRegeneracion = 10f;
            mejoraescudo.destruirEscudo(); //Mejora escudo
            if (Mejorapinchos)
            {
                collision.gameObject.GetComponent<VidaEnemigo>().contadorImpactosPicnchos++;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Enemigo"))
        {
            ataque = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bala" && mejoraescudo.escudoactivo == false) {
            if (mejoraDefensa)
            {
                vida -= 0.5f / 2f;
            }
            else
            {
                vida -= 0.5f;
            }
            StartCoroutine(shakeCamara.Shake());
            cooldownRegeneracion = 10f;
        }
        if (other.gameObject.tag == "bala" && mejoraescudo.escudoactivo == true)
        {
            mejoraescudo.destruirEscudo();//Mejora escudo
            if (mejoraDefensa)
            {
                vida -= 0f;
            }
            else
            {
                vida -= 0f;
            }
            StartCoroutine(shakeCamara.Shake());
            cooldownRegeneracion = 10f;
        }
    }
    private void MejoraRegeneracionVida() {
        float porcentajeVida =1f;
        if (vida < porcentajeVida)
        {
            vida += 0.0625f;
            
        }
    }

}

