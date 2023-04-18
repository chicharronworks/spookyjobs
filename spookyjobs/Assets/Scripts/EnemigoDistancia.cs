using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDistancia : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cubo;
    public GameObject bala;
    public GameObject pistola;
    public float velocidad;
    float turn;
    Vector2 direccion;
    RaycastHit hit;
    GameObject proyectil;
    float tiempodisparo;

    float random;
    float random2;
    bool check;
    Rigidbody rigi;
    MejoraMinion minion; //Mejora minion
    void Start()
    {
        tiempodisparo = 1.5f;
        rigi = transform.GetComponent<Rigidbody>();
        cubo = GameObject.Find("Cube");
        check = true;
        velocidad = 1f;
        minion = FindObjectOfType<MejoraMinion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("minion")) //Mejora minion
        {
            transform.LookAt(new Vector3(cubo.transform.position.x, transform.localScale.y, cubo.transform.position.z));
            ataqueDistancia();
        }
        if (GameObject.FindGameObjectWithTag("minion")) //Mejora minion
        {
            transform.LookAt(new Vector3(minion.minionInstanciado.transform.position.x, transform.localScale.y, minion.minionInstanciado.transform.position.z));
            ataqueDistanciaMinion();
        }
        moverse();
    }
    void ataqueDistancia()
    {
        Vector3 v = new Vector3(transform.position.x,transform.position.y-0.15f,transform.position.z);
        Ray ray = new Ray(v,transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag=="cubo") {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
                if (tiempodisparo <= 0)
                {
                    proyectil = Instantiate(bala, pistola.transform.position, pistola.transform.rotation);
                    proyectil.GetComponent<Rigidbody>().AddForce(pistola.transform.forward * 20, ForceMode.Impulse);
                    Destroy(proyectil, 2f);
                    //tiempodisparo = Random.Range(0, 3);
                    tiempodisparo = 2.5f;
                }
                else
                {
                    tiempodisparo -= Time.deltaTime;
                }
            } 
            else {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }
            

        }
    }
    void ataqueDistanciaMinion() //Mejora minion
    {
        Vector3 v = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);
        Ray ray = new Ray(v, transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "minion")
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
                if (tiempodisparo <= 0)
                {
                    proyectil = Instantiate(bala, pistola.transform.position, pistola.transform.rotation);
                    proyectil.GetComponent<Rigidbody>().AddForce(pistola.transform.forward * 20, ForceMode.Impulse);
                    Destroy(proyectil, 2f);
                    tiempodisparo = 2.5f;
                }
                else
                {
                    tiempodisparo -= Time.deltaTime;
                }
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }


        }
    }
    void moverse()
    {

        if (random <= 0 || check == true)
        {
            
            check = false;
            random = UnityEngine.Random.Range(3, 8);
            random2 = UnityEngine.Random.Range(0, 8);

        }
        else
        {
            random-=Time.deltaTime;
            switch (random2)
            {
                case 0: rigi.velocity = new Vector3(0, 0, velocidad); break;
                case 1: rigi.velocity = new Vector3(velocidad, 0, 0); break;
                case 2: rigi.velocity = new Vector3(0, 0, -velocidad); break;
                case 3: rigi.velocity = new Vector3(-velocidad, 0, 0); break;
                case 4: rigi.velocity = new Vector3(velocidad, 0, velocidad); break;
                case 5: rigi.velocity = new Vector3(-velocidad, 0, velocidad); break;
                case 6: rigi.velocity = new Vector3(velocidad, 0, -velocidad); break;
                case 7: rigi.velocity = new Vector3(-velocidad, 0, -velocidad); break;
                case 8: rigi.velocity = new Vector3(0, 0, 0); break;

            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            check = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "esferaastral")
        {
            velocidad = 0.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "esferaastral")
        {
            velocidad = 1f;
        }
    }
}
