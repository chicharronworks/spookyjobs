using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] float contadorTiempo = 3;
    public shakeCamara shakeCamara;
    public GameObject bombefecto;
    GameObject boom;
    public GameObject refboom;
    public ParticleSystem particulasbomba;
    MeshRenderer ms;
    // Start is called before the first frame update
    private void Start()
    {
        shakeCamara = FindObjectOfType<shakeCamara>();
        ms = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        contadorTiempo -= Time.deltaTime;
        if (contadorTiempo <= 0)
        {
            explotar();
        }
    }
    public void explotar()
    {
        ms.enabled = false;
        boom = Instantiate(bombefecto, refboom.transform.position, bombefecto.transform.rotation);
        particulasbomba.Play();
        Destroy(boom, 0.3f);
        StartCoroutine(shakeCamara.Shake());
        Collider[] objetos = Physics.OverlapSphere(transform.position, radio);
        foreach (Collider colisionador in objetos)
        {
            Rigidbody rb = colisionador.GetComponent<Rigidbody>();
            if(rb != null)
            {
                Vector3 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rb.AddForce(direccion * fuerzaFinal);
                if (colisionador.gameObject.tag == "Enemigo") Destroy(colisionador.gameObject);
            }
        }
        Destroy(gameObject,0.3f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
