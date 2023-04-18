using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEncimaEnemigo : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Texture2D cursorApuntado;
    public Vector2 hotspot;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorApuntado, hotspot, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
    }
}
