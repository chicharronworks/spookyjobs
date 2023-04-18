using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class recoleccionMoneda : MonoBehaviour
{
    public TMP_Text textoMonedas;
    public float monedas = 0000;
    public GameObject monefecto;
    GameObject clin;
    public GameObject refclin;
    MejoraMonedas mejoraM;

    // Start is called before the first frame update
    void Start()
    {
        mejoraM = FindObjectOfType<MejoraMonedas>();
    }

    // Update is called once per frame
    void Update()
    {
        textoMonedas.text = monedas.ToString();
    }
    public void sumarMonedas()
    {
        monedas += 1 * mejoraM.multiplicador;
        clin = Instantiate(monefecto, refclin.transform.position, monefecto.transform.rotation);
        Destroy(clin, 0.3f);
    }
}
