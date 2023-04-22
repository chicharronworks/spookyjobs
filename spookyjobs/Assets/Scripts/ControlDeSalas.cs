using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeSalas : MonoBehaviour
{
    public GameObject modeloSala1;
    public GameObject modeloSala2;
    public GameObject modeloSala3;
    [SerializeField] GameObject modeloSala4;
    [SerializeField] GameObject modeloSala5;
    [SerializeField] GameObject modeloSala6;
    [SerializeField] GameObject modeloSalaBoss;
    public GameObject sala1;
    int randomSala;
    public GameObject personaje;
    public GameObject spawnPersonaje;
    public GameObject spawnPersonaje2;
    Movimiento mov;
    public GameObject puertaCerrada;
    public GameObject puertaAbierta;
    GameObject puerta;
    bool puertaA;
    float contadorC;
    public AudioSource source;
    public AudioClip puertaDesbloqueadaSonido;
    public CameraFade fadeCam;
    public int contadorDeSalasCompletadas;
    [SerializeField] GameObject salaboss;
    // Start is called before the first frame update
    void Start()
    {
        contadorDeSalasCompletadas = 0;
        salaboss.SetActive(true);
        fadeCam = FindObjectOfType<CameraFade>();
        fadeCam.Fade();
        contadorC = 0f;
        mov = FindObjectOfType<Movimiento>();
        InstanciarSala();
        puertaA = false;
    }

    // Update is called once per frame
    void Update()
    {
        puertaCerrada = GameObject.FindGameObjectWithTag("puerta");
        contadorC += Time.deltaTime;
        if(!GameObject.FindGameObjectWithTag("Enemigo")&&puertaA == false&&contadorC > 0.5f)
        {
            Vector3 v = new Vector3(puertaCerrada.transform.position.x, puertaAbierta.transform.position.y, puertaCerrada.transform.position.z);
            Vector3 r = new Vector3(puertaCerrada.transform.rotation.eulerAngles.x + 90, puertaCerrada.transform.rotation.eulerAngles.y+90, puertaCerrada.transform.rotation.eulerAngles.z + 90);
            source.PlayOneShot(puertaDesbloqueadaSonido);
            puertaCerrada.SetActive(false);
            puerta = Instantiate(puertaAbierta, v, Quaternion.Euler(r));
            puertaA = true;
        }
        if(mov.finSala == true)
        {
            Destroy(puerta);
            DestruirSala();
            InstanciarSala();
            puertaA = false;
            mov.finSala = false;
        }
    }
    public void InstanciarSala()
    {
        fadeCam.Fade();
        contadorC = 0f;
        if(contadorDeSalasCompletadas < 10)
        {
            randomSala = Random.Range(1, 7);
            switch (randomSala)
            {
                case 1:
                    sala1 = Instantiate(modeloSala1, modeloSala1.transform.position, modeloSala1.transform.rotation);
                    personaje.transform.position = spawnPersonaje.transform.position;
                    break;
                case 2:
                    sala1 = Instantiate(modeloSala2, modeloSala2.transform.position, modeloSala2.transform.rotation);
                    personaje.transform.position = spawnPersonaje.transform.position;
                    break;
                case 3:
                    sala1 = Instantiate(modeloSala3, modeloSala3.transform.position, modeloSala3.transform.rotation);
                    personaje.transform.position = spawnPersonaje.transform.position;
                    break;
                case 4:
                    sala1 = Instantiate(modeloSala4, modeloSala4.transform.position, modeloSala4.transform.rotation);
                    personaje.transform.position = spawnPersonaje.transform.position;
                    break;
                case 5:
                    sala1 = Instantiate(modeloSala5, modeloSala5.transform.position, modeloSala5.transform.rotation);
                    personaje.transform.position = spawnPersonaje.transform.position;
                    break;
                case 6:
                    sala1 = Instantiate(modeloSala6, modeloSala6.transform.position, modeloSala6.transform.rotation);
                    personaje.transform.position = spawnPersonaje2.transform.position;
                    break;
            }
        }
       
    }
    public void DestruirSala()
    {
        Destroy(sala1);
        contadorDeSalasCompletadas++;
    }
}
