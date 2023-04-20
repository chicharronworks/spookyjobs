using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarBomba : MonoBehaviour
{
    public GameObject bomba;
    bool bombaDisponible;
    float contadorBomba;
    public bool ObjetoBomba;
    // Start is called before the first frame update
    void Start()
    {
        ObjetoBomba = false;
        contadorBomba = 5;
        bombaDisponible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjetoBomba == true)
        {
            if (bombaDisponible == false)
            {
                contadorBomba -= Time.deltaTime;
                if (contadorBomba <= 0)
                {
                    bombaDisponible = true;
                }
            }
            if ((Input.GetKey(KeyCode.E) || Input.GetButtonDown("R1") == true) && bombaDisponible == true)
            {
                bombaDisponible = false;
                contadorBomba = 5;
                Instantiate(bomba, transform.position, bomba.transform.rotation);
            }
        }
       
    }
}
