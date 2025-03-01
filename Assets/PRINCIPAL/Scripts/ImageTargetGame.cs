using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetGame : MonoBehaviour
{
    private Dictionary<ObserverBehaviour, string> trackedTargets = new Dictionary<ObserverBehaviour, string>();
    public bool bothPlayersReady = false; // Variable que indica si ambos jugadores están listos

    [SerializeField] private GameObject aviso;

    public string ganadorColor { get; private set; }
    public string ganadorPersonaje { get; private set; }

    void Start()
    {
        ObserverBehaviour[] trackables = FindObjectsOfType<ObserverBehaviour>();

        foreach (ObserverBehaviour trackable in trackables)
        {
            trackable.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour trackable, TargetStatus status)
    {
        string targetName = trackable.TargetName.ToLower();

        if (status.Status == Status.TRACKED && !trackedTargets.ContainsKey(trackable))
        {
            trackedTargets.Add(trackable, targetName);
        }
        else if (status.Status != Status.TRACKED && trackedTargets.ContainsKey(trackable))
        {
            trackedTargets.Remove(trackable);
        }

        UpdatePlayersStatus();
        CheckWinner();
    }

    private void UpdatePlayersStatus()
    {
        bool hasRojo = false;
        bool hasAzul = false;

        foreach (string name in trackedTargets.Values)
        {
            if (name.Contains("rojo")) hasRojo = true;
            if (name.Contains("azul")) hasAzul = true;
        }

        // La variable solo será true si hay exactamente un "rojo" y un "azul"
        bothPlayersReady = hasRojo && hasAzul;
    }

    private void CheckWinner()
    {
        if (!bothPlayersReady)
        {
            Debug.Log("Esperando a ambos jugadores...");
            aviso.SetActive(true);
            return;
        }

        aviso.SetActive(false);

        string rojo = null;
        string azul = null;

        foreach (string name in trackedTargets.Values)
        {
            if (name.Contains("rojo")) rojo = name;
            else if (name.Contains("azul")) azul = name;
        }

        string tipoRojo = rojo.Replace("rojo", "").Trim();
        string tipoAzul = azul.Replace("azul", "").Trim();

        int resultado = DeterminarGanador(tipoRojo, tipoAzul);

        if (resultado == 1)
        {
            ganadorColor = "Rojo";
            ganadorPersonaje = tipoRojo;
            Debug.Log($"¡Gana ROJO con {tipoRojo} contra {tipoAzul}!");
        }
        else if (resultado == -1)
        {
            ganadorColor = "Azul";
            ganadorPersonaje = tipoAzul;
            Debug.Log($"¡Gana AZUL con {tipoAzul} contra {tipoRojo}!");
        }
        else
        {
            ganadorColor = "Empate";
            ganadorPersonaje = "Ninguno";
            Debug.Log($"Empate entre {tipoRojo} y {tipoAzul}.");
        }
    }

    private int DeterminarGanador(string jugador1, string jugador2)
    {
        if (jugador1 == jugador2) return 0;

        if ((jugador1 == "guerrero" && jugador2 == "mago") ||
            (jugador1 == "mago" && jugador2 == "arquera") ||
            (jugador1 == "arquera" && jugador2 == "guerrero"))
        {
            return 1;
        }
        return -1;
    }
}
