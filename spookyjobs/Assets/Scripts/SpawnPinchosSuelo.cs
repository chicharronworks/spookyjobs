using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPinchosSuelo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pinchos;
    float posx;
    float posz;
    int RandomPinchos;
    void Start()
    {
        RandomPinchos = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] pin = GameObject.FindGameObjectsWithTag("PinchosSuelo");
        if (pin.Length < RandomPinchos)
        {
            SpawnPinchos();
        }
        
    }
    void SpawnPinchos()
    {
        
        Vector3 pspawn = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Vector3 rot = new Vector3(pinchos.transform.rotation.eulerAngles.x, Random.Range(0, 360), pinchos.transform.rotation.eulerAngles.z);
        posx = Random.Range((transform.position.x-pspawn.x)/2.5f,(transform.position.x+pspawn.x)/2.5f);
        posz = Random.Range((transform.position.z-pspawn.z)/2.5f,(transform.position.z+pspawn.z)/2.5f);
        Instantiate(pinchos,new Vector3(posx,pinchos.transform.position.y,posz),Quaternion.Euler(rot));

    }
}
