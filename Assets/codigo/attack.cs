using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject parrry;


    private void Start()
    {
        parrry.GetComponent<BoxCollider>().enabled = false;
    }
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("parry");
            parrry.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(finAtaque());
        }
    }
    IEnumerator finAtaque()
    {
        yield return new WaitForSeconds (0.3f);
        parrry.GetComponent<BoxCollider>().enabled = false;
    }
}
