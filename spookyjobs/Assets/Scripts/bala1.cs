using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Escenario" || other.gameObject.tag == "puerta" || other.gameObject.tag=="cubo")
        {
            Destroy(transform.gameObject);
        }
    }
}
