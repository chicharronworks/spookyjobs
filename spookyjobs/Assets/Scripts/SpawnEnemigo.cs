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
        Vector3 v = new Vector3(transform.position.x, enemigo.transform.position.y, transform.position.z);
        Vector3 v2 = new Vector3(transform.position.x, enemigo1.transform.position.y, transform.position.z);
        if (comienzoSpawn == 0)
        {
            contador += Time.deltaTime;
            if (contador >= 0.4f)
            {
                Instantiate(enemigo, v, enemigo.transform.rotation);
                Instantiate(enemigo1, v2, enemigo1.transform.rotation);
                comienzoSpawn = 1;
            }
        }
    }
}
