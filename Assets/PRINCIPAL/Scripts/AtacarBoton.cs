using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Vuforia;
using TMPro;

public class AtacarBoton : MonoBehaviour
{
    [SerializeField] ImageTargetGame game;
    [SerializeField] private Animator[] animator;
    [SerializeField] private TextMeshProUGUI[] texto;
    [SerializeField] private GameObject emapate;
    private string colorGanador;
    private string personajeGanador;
    private int puntajeR = 0;
    private int puntajeA = 0;

    public void ApagarEmpate()
    {
        emapate.SetActive(false);
    }

    private void OnMouseDown()
    {

        if (game != null)
        {
            colorGanador = game.ganadorColor;
            personajeGanador = game.ganadorPersonaje;
        }

        if(colorGanador == "Rojo")
        {
            animator[0].SetTrigger("Atacar");
            animator[1].SetTrigger("Atacar");
            animator[2].SetTrigger("Atacar");

            animator[3].SetTrigger("Perder");
            animator[4].SetTrigger("Perder");
            animator[5].SetTrigger("Perder");

            puntajeR++; 
            texto[0].text = puntajeR.ToString(); 
        }
        else if (colorGanador == "Azul")
        {
            animator[3].SetTrigger("Atacar");
            animator[4].SetTrigger("Atacar");
            animator[5].SetTrigger("Atacar");

            animator[0].SetTrigger("Perder");
            animator[1].SetTrigger("Perder");
            animator[2].SetTrigger("Perder");

            puntajeA++;
            texto[1].text = puntajeA.ToString();
        }
        else
        {
            emapate.SetActive(true); 
        }

        Debug.Log($"El ganador es {colorGanador} con {personajeGanador}");
    }
}
