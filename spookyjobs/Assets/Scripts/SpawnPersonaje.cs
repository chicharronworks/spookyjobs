using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPersonaje : MonoBehaviour
{
    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(personaje, personaje.transform.position, personaje.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
