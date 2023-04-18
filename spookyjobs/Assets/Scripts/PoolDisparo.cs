using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDisparo : MonoBehaviour
{
    [SerializeField] private GameObject prefabDisparo;
    [SerializeField] private int tama�oPool = 20;
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
        a�adirDisparosALaPool(tama�oPool);
    }
    private void a�adirDisparosALaPool(int cantidad)
    {
        for (int i = 0; i < tama�oPool; i++)
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
        a�adirDisparosALaPool(1);
        listaDisparos[listaDisparos.Count - 1].SetActive(true);
        return listaDisparos[listaDisparos.Count - 1];
    }
}
