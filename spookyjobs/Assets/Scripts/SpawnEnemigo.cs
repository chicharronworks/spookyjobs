using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{
    public GameObject enemigo;
    public GameObject enemigo1;
    int comienzoSpawn;
    float contador;
    // Start is called before the first frame update
    void Start()
    {
        comienzoSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (comienzoSpawn == 0)
        {
            contador += Time.deltaTime;
            if (contador >= 0.4f)
            {
                Instantiate(enemigo, enemigo.transform.position, enemigo.transform.rotation);
                Instantiate(enemigo1, enemigo1.transform.position, enemigo1.transform.rotation);
                comienzoSpawn = 1;
            }
        }
    }
}
