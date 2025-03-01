using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CartaCentral : MonoBehaviour
{
    [SerializeField] private GameObject objetoActivar; // Objeto que se activará
    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        objetoActivar.SetActive(true); // Inicia desactivado
    }

    private void OnTargetStatusChanged(ObserverBehaviour trackable, TargetStatus status)
    {
        if (status.Status == Status.TRACKED)
        {
            objetoActivar.SetActive(false); 
        }
        else
        {
            objetoActivar.SetActive(true); 
        }
    }
}
