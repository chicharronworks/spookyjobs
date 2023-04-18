using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeCritico : MonoBehaviour
{
    [SerializeField]public int porcentajeCritico;
    public bool ataqueCritico;
    void Update()
    {
        int critico = Random.Range(1, 100);
        if(porcentajeCritico != 0)
        {
            if(critico <= porcentajeCritico)
            {
                critico = 1;
            }
            else
            {
                critico = 0;
            }
        }
        else
        {
            critico = 0;
        }
        if (critico == 1)
        {
            ataqueCritico = true;
        }
        else
        {
            ataqueCritico = false;
        }
    }
}
