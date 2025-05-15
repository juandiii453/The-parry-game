using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weekstate : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemigo")
        {
            other.GetComponent<DatosEnemigo>().health -= damage;
        }
    }

}
