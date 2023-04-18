using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeCamara : MonoBehaviour
{
    public float duracion = 1.5f;
    public Vector3 posicionOriginal;
    private void Start()
    {
        posicionOriginal = transform.position;
    }
    public IEnumerator Shake()
    {
        float tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < duracion)
        {
            tiempoTranscurrido += Time.deltaTime;
            transform.position = posicionOriginal + Random.insideUnitSphere /8;
            yield return null;
        }
        transform.position = posicionOriginal;
    }
}
