using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejoras : MonoBehaviour
{
    public PlayerController player;
    public AttackEnemy AttackEnemyC;


    public void Healthpower ()
    {
        player.health += 20;
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
    }

    public void speedpower ()
    {
        player.velocidadNormal += 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
