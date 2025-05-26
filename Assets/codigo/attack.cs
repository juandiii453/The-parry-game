using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject filo; // Referencia al objeto del filo del arma
    private BoxCollider filoCollider; // Referencia al BoxCollider del filo

    private void Start()
    {
       
        filoCollider = filo.GetComponent<BoxCollider>();
        filoCollider.enabled = false;
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetTrigger("parry");
            filoCollider.enabled = true;
            StartCoroutine(DesactivarCollider());
        }
    }

    private IEnumerator DesactivarCollider()
    {
        yield return new WaitForSeconds(0.3f);
        filoCollider.enabled = false;
    }
}

