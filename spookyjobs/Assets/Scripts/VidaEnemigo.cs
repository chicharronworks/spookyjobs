using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float vida;
    public shakeCamara shakeCamara;
    Vida vid;
    public GameObject moneda;
    public Texture2D cursorNormal;
    public Vector2 hotspot;
    public float contadorVeneno;
    public bool envenenado;
    public GameObject particulasVeneno;
    int ven;
    int pin;
    SistemaDeCritico critico;
    public float daño;
    float multiplicador;
    float tempesferaastral;
    public bool mejorapinchos;
    bool pinchando;
    float contadorPinchos;
    public int contadorImpactosPicnchos;
    [SerializeField] int probabilidadVeneno;
    bool impactado;
    bool hasidoenvenenado;
    MejoraVeneno mejoradeveneno;
    MejoraAtaque mejoradeataque;

    // Start is called before the first frame update
    void Start()
    {
        vid = GameObject.FindGameObjectWithTag("cubo").GetComponent<Vida>();
        multiplicador = 1f;
        daño = 1f;
        critico = FindObjectOfType<SistemaDeCritico>();
        ven = 0;
        pin = 0;
        particulasVeneno.SetActive(false);
        envenenado = false;
        contadorVeneno = 0f;
        vida = 3;
        shakeCamara = FindObjectOfType<shakeCamara>();
        mejoradeataque = FindObjectOfType<MejoraAtaque>();
        tempesferaastral = 0f;
        mejorapinchos = false;
        pinchando = false;
        contadorPinchos = 0f;
        impactado = false;
        hasidoenvenenado = false;
        mejoradeveneno = FindObjectOfType<MejoraVeneno>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mejoradeataque.mejoraactiva) {
            daño = 1.5f;
        } 
        else {
        daño = 1f;
        }
        if(critico.ataqueCritico == true)
        {
            multiplicador = 3f;
        }
        else
        {
            multiplicador = 1f;
        }
        if (vida <= 0)
        {
            envenenado = false;
            pinchando = false;
            Instantiate(moneda, transform.position, moneda.transform.rotation);
            Destroy(gameObject);
            Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
        }
        if (mejoradeveneno.mejoraveneno == true)
        {
            probabilidadVeneno = 20;
        }
        if (mejoradeveneno == true && hasidoenvenenado == false)
        {
            if (envenenado == false)
            {
                int vene = Random.Range(1, 100);
                if (probabilidadVeneno != 0)
                {
                    if (vene <= probabilidadVeneno)
                    {
                        vene = 1;
                    }
                    else
                    {
                        vene = 0;
                    }
                }
                else
                {
                    vene = 0;
                }
                if (vene == 1)
                {
                    envenenado = true;
                }
                else
                {
                    envenenado = false;
                }
            }

            if (envenenado == false && impactado == true)
            {
                impactado = false;
            }
            if (envenenado == true && impactado == true)
            {
                contadorVeneno += Time.deltaTime;
                particulasVeneno.SetActive(true);
                if ((contadorVeneno >= 1f && contadorVeneno <= 1.5f) && ven == 0)
                {
                    ven = 1;
                    dañoVeneno();
                }
                if ((contadorVeneno >= 2f && contadorVeneno <= 2.5f) && ven == 1)
                {
                    ven = 2;
                    dañoVeneno();
                }
                if ((contadorVeneno >= 3f && contadorVeneno <= 3.5f) && ven == 2)
                {
                    ven = 3;
                    dañoVeneno();
                }
                if ((contadorVeneno >= 4f && contadorVeneno <= 4.5f) && ven == 3)
                {
                    ven = 4;
                    dañoVeneno();
                }
                if ((contadorVeneno >= 5f && contadorVeneno <= 5.5f) && ven == 4)
                {
                    ven = 5;
                    dañoVeneno();
                }
                if (contadorVeneno > 5.5f)
                {
                    particulasVeneno.SetActive(false);
                    envenenado = false;
                    ven = 0;
                    impactado = false;
                    hasidoenvenenado = true;
                }
            }
        }
        if (vid.Mejorapinchos)
        {
            if (contadorImpactosPicnchos>1) {
                pinchando = true;
                contadorImpactosPicnchos = 0;
                
            }
            if (pinchando)
            {
                contadorPinchos += Time.deltaTime;
                if ((contadorPinchos >= 1f && contadorPinchos <= 1.5f) && pin == 0)
                {
                    ven = 1;
                    dañopinchos();
                }
                if ((contadorPinchos >= 2f && contadorPinchos <= 2.5f) && pin == 1)
                {
                    pin = 2;
                    dañoVeneno();
                }
                if ((contadorPinchos >= 3f && contadorPinchos <= 3.5f) && pin == 2)
                {
                    pin = 3;
                    dañopinchos();
                }
                if ((contadorPinchos >= 4f && contadorPinchos <= 4.5f) && pin == 3)
                {
                    pin = 4;
                    dañopinchos();
                }
                if ((contadorPinchos >= 5f && contadorPinchos <= 5.5f) && pin == 4)
                {
                    pin = 5;
                    dañopinchos();
                }
                if (contadorPinchos > 5.5f)
                {
                    pinchando = false;
                    pin = 0;
                    contadorPinchos = 0;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("arma"))
        {
            vida-= daño * multiplicador;
            StartCoroutine(shakeCamara.Shake());
            impactado = true;
            contadorImpactosPicnchos++;
            
        }
    }
    public void dañoVeneno()
    {
        vida -= 0.1f;
    }
    public void dañopinchos()
    {
        vida -= 0.01f;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "esferaastral")
        {
            if (tempesferaastral <= 0f)
            {
                vida -= 0.0625f;
                tempesferaastral = 1f;
            }
            else
            {
                tempesferaastral -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "esferaastral")
        {
            tempesferaastral = 0f;
        }
    }
}
