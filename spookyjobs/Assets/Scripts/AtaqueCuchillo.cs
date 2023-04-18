using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCuchillo : MonoBehaviour
{
    // Start is called before the first frame update
    public float daño=2;
    CapsuleCollider colliderC;
    bool checkmando;
    void Start()
    {
        checkmando = false;
        colliderC = GetComponent<CapsuleCollider>();
        colliderC.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AtaqueNavaja();
            checkmando = false;
        }
        if (Input.GetMouseButtonUp(0))
        {

            SalidaAtaqueNavaja();
        }
        if (Input.GetAxis("L2") != 0)
        {
            AtaqueNavaja();
            checkmando = true;
        }
        if (Input.GetAxis("L2") == 0 && checkmando == true)
        {
            SalidaAtaqueNavaja();
            checkmando = false;
        }


    }

    void AtaqueNavaja()
    {
        transform.localPosition = new Vector3(0 + 0.6f, 0, 0);
        colliderC.enabled = true;
    }
    void SalidaAtaqueNavaja()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        colliderC.enabled = false;
    }
    


}
