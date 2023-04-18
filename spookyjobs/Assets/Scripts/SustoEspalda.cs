using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SustoEspalda : MonoBehaviour
{
    public bool susto;
    public GameObject pantallaSusto1;
    // Start is called before the first frame update
    void Start()
    {
        susto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (susto == true)
        {
            GameObject pantallaSusto = Instantiate(pantallaSusto1, pantallaSusto1.transform.position, pantallaSusto1.transform.rotation);
            Destroy(pantallaSusto, 0.2f);
            susto = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            susto = true;
        }
    }
}
