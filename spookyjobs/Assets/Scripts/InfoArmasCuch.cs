using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoArmasCuch : MonoBehaviour
{
    public GameObject infoCuch;
    public GameObject cuchillo;
    bool cuchilloDisponible;
    public GameObject Cuch;
    public GameObject Pist;
    public GameObject Cuch2;
    public GameObject Pist2;
    // Start is called before the first frame update
    void Start()
    {
        infoCuch.SetActive(false);
        cuchilloDisponible = false;
        cuchillo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cuchilloDisponible== true)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                cuchillo.SetActive(true);
                Cuch.SetActive(false);
                Pist.SetActive(false);
                Cuch2.SetActive(false);
                Pist2.SetActive(false);
                infoCuch.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cubo")
        {
            infoCuch.SetActive(true);
            cuchilloDisponible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cubo")
        {
            infoCuch.SetActive(false);
            cuchilloDisponible = false;
        }
    }
}
