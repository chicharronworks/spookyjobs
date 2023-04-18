using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public float contadorInicio;
    public Transform objetoAlQueSeguir = null;
    public float velocidad = 15;
    public GameObject jugador;
    public recoleccionMoneda recoleccion;
    // Start is called before the first frame update
    void Start()
    {
        recoleccion = FindObjectOfType<recoleccionMoneda>();
        contadorInicio = 0.8f;
        jugador = GameObject.FindGameObjectWithTag("cubo");
        objetoAlQueSeguir = jugador.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        contadorInicio -= Time.deltaTime;
        if(contadorInicio <= 0)
        {
            if (objetoAlQueSeguir == null) return;
            transform.position = Vector3.MoveTowards(transform.position, objetoAlQueSeguir.transform.position, velocidad * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cubo")
        {
            recoleccion.sumarMonedas();
            Destroy(gameObject);
        }
    }
}
