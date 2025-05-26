using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameover : MonoBehaviour 
{
    [SerializeField] private GameObject menuGameOver;
    private PlayerController playerController;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerController = playerObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Suscribirse al evento de muerte del jugador
                playerController.MuerteJugador += ActivarMenu;
            }
        }

        // Asegurarse que el menú esté desactivado al inicio
        menuGameOver.SetActive(false);
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }

    public void Reiniciar()
    {
        Debug.Log("Reiniciar presionado");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void salir()
    {
        Debug.Log("Salir presionado");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
