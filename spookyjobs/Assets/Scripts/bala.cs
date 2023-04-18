using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    //public float velocidadDisparo = 500f;
    //public Rigidbody disparorb;

    // Start is called before the first frame update
    void Start()
    {
        //disparorb.AddForce(transform.forward * velocidadDisparo);
        //disparorb.velocity = transform.forward * velocidadDisparo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo"||other.gameObject.tag == "Escenario" || other.gameObject.tag == "puerta")
        {
            Destroy(transform.gameObject);
            //gameObject.SetActive(false);
        }
    }
}
