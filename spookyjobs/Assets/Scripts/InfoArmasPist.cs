using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoArmasPist : MonoBehaviour
{
    public GameObject infoPist;
    public GameObject Pistola;
    bool pistolaDisponible;
    public GameObject Cuch;
    public GameObject Pist;
    public GameObject Cuch2;
    public GameObject Pist2;
    // Start is called before the first frame update
    void Start()
    {
        infoPist.SetActive(false);
        pistolaDisponible = false;
        Pistola.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pistolaDisponible == true)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                Pistola.SetActive(true);
                Cuch.SetActive(false);
                Pist.SetActive(false);
                Cuch2.SetActive(false);
                Pist2.SetActive(false);
                infoPist.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cubo")
        {
            infoPist.SetActive(true);
            pistolaDisponible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cubo")
        {
            infoPist.SetActive(false);
            pistolaDisponible = false;
        }
    }
}
