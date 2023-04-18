using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraMinion : MonoBehaviour
{
    [SerializeField] bool mejoraActiva;
    [SerializeField] GameObject minion;
    [SerializeField] GameObject personaje;
    public GameObject minionInstanciado;
    [SerializeField] float cooldown;
    [SerializeField] bool minionDisponible;
    public bool minionVivo;
    float tiempoVivo;
    // Start is called before the first frame update
    void Start()
    {
        minionVivo = false;
        mejoraActiva = false;
        minionDisponible = true;
        cooldown = 10f;
        tiempoVivo = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(mejoraActiva == true && minionDisponible == false && minionVivo == false)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0f)
            {
                minionDisponible = true;
                cooldown = 10f;
            }
        }
        if(minionDisponible == true && Input.GetKey(KeyCode.M) && mejoraActiva == true)
        {
            minionInstanciado = Instantiate(minion, personaje.transform.position, minion.transform.rotation);
            minionDisponible = false;
            minionVivo = true;
            tiempoVivo = 5f;
        }
        if(minionVivo == true)
        {
            tiempoVivo -= Time.deltaTime;
            if(tiempoVivo <= 0)
            {
                minionVivo = false;
            }
        }
    }
}
