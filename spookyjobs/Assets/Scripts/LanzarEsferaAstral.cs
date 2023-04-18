using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarEsferaAstral : MonoBehaviour

{
    // Start is called before the first frame update
    public GameObject esfera;
    public GameObject esfera1;
    float cooldownesfera;
    void Start()
    {
        cooldownesfera = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) && cooldownesfera<=0)
        {
            Debug.Log("entra");
            Vector3 v = new Vector3(transform.position.x,esfera.transform.position.y,transform.position.z);
            esfera1 = Instantiate(esfera, v, esfera.transform.rotation);
            Destroy(esfera1, 10f);
            cooldownesfera = 5f;
        }
        if (cooldownesfera > 0)
        {
            cooldownesfera -= Time.deltaTime;
        }
    }
}
