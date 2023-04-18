using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDisparo : MonoBehaviour
{
    [SerializeField] private GameObject prefabDisparo;
    [SerializeField] private int tamañoPool = 20;
    [SerializeField] private List<GameObject> listaDisparos;
    private static PoolDisparo instance;
    public static PoolDisparo Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        añadirDisparosALaPool(tamañoPool);
    }
    private void añadirDisparosALaPool(int cantidad)
    {
        for (int i = 0; i < tamañoPool; i++)
        {
            GameObject disparo = Instantiate(prefabDisparo);
            disparo.SetActive(false);
            listaDisparos.Add(disparo);
            disparo.transform.parent = transform;
        }
    }
    public GameObject PedirDisparo()
    {
        for (int i = 0; i < listaDisparos.Count; i++)
        {
            if(!listaDisparos[i].activeSelf)
            {
                listaDisparos[i].SetActive(true);
                return listaDisparos[i];
            }
        }
        añadirDisparosALaPool(1);
        listaDisparos[listaDisparos.Count - 1].SetActive(true);
        return listaDisparos[listaDisparos.Count - 1];
    }
}
