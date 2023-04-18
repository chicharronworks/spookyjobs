using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDistancia : MonoBehaviour
{
    public GameObject bala;
    public bool disparo;
    GameObject proyectil;
    public GameObject bangefecto;
    GameObject bang;
    public GameObject refbang;
    // Start is called before the first frame update
    void Start()
    {
        disparo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetAxis("R2") != 0)
        {
            if (disparo == true)
            {
                proyectil = Instantiate(bala, transform.position, transform.rotation);
                //proyectil = PoolDisparo.Instance.PedirDisparo();
                //proyectil.transform.position = transform.position;
                //proyectil.transform.rotation = transform.rotation;
                bang = Instantiate(bangefecto, refbang.transform.position, bangefecto.transform.rotation);
                Destroy(bang, 0.3f);
                proyectil.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
                disparo = false;
                Destroy(proyectil, 2f);
            }
        }
        if (Input.GetMouseButtonUp(1) || Input.GetAxis("R2") == 0)
        {
            if (disparo == false)
            {
                disparo = true;
            }
        }
    }
}
