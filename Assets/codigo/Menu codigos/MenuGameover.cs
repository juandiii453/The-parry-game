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
        if (!playerObject.activeInHierarchy)
        {
            playerController = playerObject.GetComponent<PlayerController>();
            if (!playerObject.activeInHierarchy)
            {
                playerController.MuerteJugador += ActivarMenu;
            }
            /*else
            {
                Debug.LogError("PlayerController no encontrado en el objeto con tag 'Player'");
            }*/
        }
       /*else
        {
            Debug.LogError("No se encontró un GameObject con tag 'Player' en la escena.");
        }*/
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