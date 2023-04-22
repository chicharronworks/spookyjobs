using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MúsicaMenú : MonoBehaviour
{
    float duracionPrimeraParteAudioMenu;
    [SerializeField] GameObject Audio2Loop;
    // Start is called before the first frame update
    void Start()
    {
        Audio2Loop.SetActive(false);
        duracionPrimeraParteAudioMenu = 72;
    }

    // Update is called once per frame
    void Update()
    {
        duracionPrimeraParteAudioMenu -= Time.deltaTime;
        if(duracionPrimeraParteAudioMenu <= 0)
        {
            Audio2Loop.SetActive(true);
        }
    }
}
