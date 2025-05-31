using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejoras : MonoBehaviour
{
    public PlayerController player;
    public AttackEnemy AttackEnemyC;
    public GameObject canvasMejoras;
    public GameObject jugador;


    public void Healthpower ()
    {
        player.health += 20;
        activar_personaje();
    }
    public void damagepower()
    {
    // Encuentra todos los objetos con el tag "arma"
    GameObject[] armas = GameObject.FindGameObjectsWithTag("arma");

    foreach (GameObject arma in armas)
    {
        // Asegúrate de que el objeto tenga el componente que controla el daño
        AttackEnemy componenteAtaque = arma.GetComponent<AttackEnemy>();
        if (componenteAtaque != null)
        {
            componenteAtaque.damage += 5;
        }

    }
    activar_personaje();
    }

    public void speedpower ()
    {
        player.velocidadNormal += 1;
        activar_personaje();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void activar_personaje()
    {
     canvasMejoras.SetActive(false);

        if (jugador != null)
            jugador.SetActive(true);

            // Mostrar y desbloquear cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
}
