using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject filo; // Referencia al objeto del filo del arma
    private BoxCollider filoCollider; // Referencia al BoxCollider del filo

    private void Start()
    {
        // Obtén el componente BoxCollider del filo y desactívalo al inicio
        filoCollider = filo.GetComponent<BoxCollider>();
        filoCollider.enabled = false;
    }

    private void Update()
    {
        // Detecta si el jugador presiona el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Activa la animación de parry
            GetComponent<Animator>().SetTrigger("parry");

            // Activa el collider del filo al inicio del ataque
            filoCollider.enabled = true;

            // Inicia la coroutine para desactivar el collider después de un tiempo
            StartCoroutine(DesactivarCollider());
        }
    }

    private IEnumerator DesactivarCollider()
    {
        // Espera el tiempo que dure la animación del parry (ajusta según sea necesario)
        yield return new WaitForSeconds(0.3f);

        // Desactiva el collider del filo después de la espera
        filoCollider.enabled = false;
    }
}

