using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoJugador : MonoBehaviour
{
    public Transform objetoAlQueSeguir = null;
    public float velocidad = 5;
    public GameObject jugador;
    MejoraMinion minion; //Mejora minion

    // Update is called once per frame
    void Update()
    {
        if (objetoAlQueSeguir == null) return;
        if (!GameObject.FindGameObjectWithTag("minion")) //Mejora minion
        {
            transform.position = Vector3.MoveTowards(transform.position, objetoAlQueSeguir.transform.position, velocidad * Time.deltaTime);
        }
        if (GameObject.FindGameObjectWithTag("minion")) //Mejora minion
        {
            transform.position = Vector3.MoveTowards(transform.position, minion.minionInstanciado.transform.position, velocidad * Time.deltaTime);
        }
    }
    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("cubo");
        objetoAlQueSeguir = jugador.GetComponent<Transform>();
        minion = FindObjectOfType<MejoraMinion>(); //Mejora minion
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "esferaastral")
        {
            velocidad = 1f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "esferaastral")
        {
            velocidad = 2f;
        }
    }
}
