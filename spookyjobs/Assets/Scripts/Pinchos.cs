using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    // Start is called before the first frame update
    public float temporizador;
    float temporizador1;
    float y;
    bool bajando;

    public GameObject[] escen;
    void Start()
    {
        
        
        y = transform.position.y;
        bajando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bajando)
        {
            if (transform.position.y > -0.3f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.0001f, transform.position.z);
            }
            else { bajando = false; }
        }
        if(bajando==false)
        {
            if(transform.position.y < y) {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.0001f, transform.position.z);
            }
            else { bajando = true; }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Escenario" || other.gameObject.tag == "PinchosSuelo")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Escenario" || collision.gameObject.tag == "PinchosSuelo")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Escenario" || other.gameObject.tag == "PinchosSuelo")
        {
            Destroy(gameObject);
        }
    }

}
