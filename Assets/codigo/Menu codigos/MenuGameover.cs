using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuGameover : MonoBehaviour 
{
    [SerializeField] private GameObject menuGameOver;
    private PlayerController playerController;

    // Start is called before the first frame update
   private void Start()
{
    GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
    if (playerObject != null)
    {
        playerController = playerObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.MuerteJugador += ActivarMenu;
        }
        else
        {
            Debug.LogError("PlayerController no encontrado en el objeto con tag 'Player'");
        }
    }
    else
    {
        Debug.LogError("No se encontró un GameObject con tag 'Player' en la escena.");
    }
}

    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
