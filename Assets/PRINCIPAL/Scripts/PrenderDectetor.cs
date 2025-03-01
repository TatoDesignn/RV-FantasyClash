using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PrenderDectetor : MonoBehaviour
{
    [SerializeField] private GameObject objetoActivar; // Objeto que se activará
    [SerializeField] private GameObject objetoPersonaje; // Objeto que se activará
    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        objetoActivar.SetActive(false); // Inicia desactivado
    }

    private void OnTargetStatusChanged(ObserverBehaviour trackable, TargetStatus status)
    {
        if (status.Status == Status.TRACKED)
        {
            objetoActivar.SetActive(true); // Activa el objeto cuando se detecta
        }
        else
        {
            objetoActivar.SetActive(false); // Lo desactiva cuando se pierde
            objetoPersonaje.SetActive(false); // Lo desactiva cuando se pierde
        }
    }
}
