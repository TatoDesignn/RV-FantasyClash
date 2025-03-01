using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    ImageTargetGame game;

    [SerializeField] private mostrar mostrarP;
    [SerializeField] private GameObject tarjeta;
    [SerializeField] private GameObject centro;
    [SerializeField] private GameObject personaje;
    [SerializeField] private GameObject listo;
    [SerializeField] private GameObject botonAtacar;
    [SerializeField] private GameObject botonAtacar2;
    [SerializeField] private float distanciaActivar;

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ImageTargetGame>();
    }

    private void Update()
    {
        Vector3 direccionCentro = centro.transform.position - tarjeta.transform.position;
        float distancia = direccionCentro.magnitude;

        if (distancia <= distanciaActivar && !game.bothPlayersReady)
        {
            Debug.Log("Entre2;");
            listo.SetActive(true);
            personaje.SetActive(false);
            botonAtacar.SetActive(false);
            botonAtacar2.SetActive(false);

            mostrarP.mostrarPersonajes = false;
        }
        else if (distancia <= distanciaActivar && game.bothPlayersReady && mostrarP.mostrarPersonajes == false)
        {
            Debug.Log("Entre;");
            botonAtacar.SetActive(true);
            listo.SetActive(true);

            personaje.transform.rotation = Quaternion.LookRotation(direccionCentro);
        }
        else if (mostrarP.mostrarPersonajes)
        {
            activarPersonajes();
        }
        else
        {
            Debug.Log("Entre3;");
            personaje.SetActive(false);
            botonAtacar.SetActive(false);
            botonAtacar2.SetActive(false);
            listo.SetActive(false);
        }
    }

    private void activarPersonajes()
    {
        personaje.SetActive(true);
        listo.SetActive(false);
        botonAtacar.SetActive(false);
        botonAtacar2.SetActive(true);

    }
}
