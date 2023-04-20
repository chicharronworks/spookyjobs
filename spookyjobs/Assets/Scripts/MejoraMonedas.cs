using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraMonedas : MonoBehaviour
{
    public float multiplicador;
    public bool MasDosMonedas;
    // Start is called before the first frame update
    void Start()
    {
        MasDosMonedas = false;
    }

    private void Update()
    {
        if (MasDosMonedas == false)
        {
            multiplicador = 1f;
        }

        if (MasDosMonedas == true)
        {
            multiplicador = 1.5f;
        }
    }
}
