using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoArmaBloqueada : MonoBehaviour
{
    public GameObject infoBloq;
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
        if (other.gameObject.tag == "cubo")
        {
            infoBloq.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cubo")
        {
            infoBloq.SetActive(false);
        }
    }
}
