using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrar : MonoBehaviour
{
    public bool mostrarPersonajes = false;

    private void Start()
    {
        mostrarPersonajes = false;
    }

    private void OnMouseDown()
    {
        mostrarPersonajes = true;
    }
}
