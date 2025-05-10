using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject Filo;


    private void Start()
    {
        Filo.GetComponent<BoxCollider>().isTrigger = false;
    }
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("parry");
            Filo.GetComponent<BoxCollider>().isTrigger = true;
            StartCoroutine(finAtaque());
        }
    }
    IEnumerator finAtaque()
    {
        yield return new WaitForSeconds (0.3f);
        Filo.GetComponent<BoxCollider>().isTrigger = false;
    }
}
