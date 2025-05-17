using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weekstate : MonoBehaviour
{
    [SerializeField]
    public int damage = 10;
    public GameObject enemigo;

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            DatosEnemigo datos = other.GetComponent<DatosEnemigo>();
            if (datos != null && datos.weekstate == true)
            {
                datos.health -= damage;
            }
        }
    }
}