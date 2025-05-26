using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMejoras : MonoBehaviour
{
    [SerializeField] private GameObject canvasMejoras;
    [SerializeField] private int enemigosParaActivar = 10;
    [SerializeField] private GameObject jugador;

    private int enemigosDerrotados = 0;

    void Start()
    {
        SuscribirEnemigos();
    }

    private void SuscribirEnemigos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");

        foreach (GameObject enemigo in enemigos)
        {
            DatosEnemigo datos = enemigo.GetComponent<DatosEnemigo>();
            if (datos != null)
            {
                datos.MuerteEnemigo += OnEnemigoMuerto;
            }
        }
    }

    private void OnEnemigoMuerto(object sender, EventArgs e)
    {
        enemigosDerrotados++;

        if (enemigosDerrotados >= enemigosParaActivar)
        {
            canvasMejoras.SetActive(true);

            if (jugador != null)
                jugador.SetActive(false);

            // Mostrar y desbloquear cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            enemigosDerrotados = 0;
        }
    }

    // Método para cerrar el canvas y volver a jugar
    public void ContinuarJuego()
    {
        canvasMejoras.SetActive(false);

        if (jugador != null)
            jugador.SetActive(true);

        // Bloquear y ocultar cursor para controlar cámara
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}


