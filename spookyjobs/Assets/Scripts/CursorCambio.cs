using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCambio : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D cursorimpc;
    public Texture2D cursormuerto;
    public Vector2 hotspot;
    public CursorMode cursorMode = CursorMode.Auto;
    public float contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Impacto()
    {
        Cursor.SetCursor(cursorimpc, hotspot, cursorMode);
        contador -= Time.deltaTime;
        if(contador <= 0)
        {
            Cursor.SetCursor(cursor, hotspot, cursorMode);
        }

    }
    void Muerte()
    {

    }
}
