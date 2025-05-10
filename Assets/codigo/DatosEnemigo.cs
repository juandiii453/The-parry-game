using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosEnemigo : MonoBehaviour
{
    public int health = 10;
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;


    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
    }

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("parry");
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 50)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
             if (cronometro >= 4)
             {
               rutina = Random.Range(0,2);
               cronometro = 0;
             }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0,360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 3 * Time.deltaTime);
                    ani.SetBool("walk",true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 3)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("walk",false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 7 * Time.deltaTime);
                ani.SetBool("attack", false);
            }
            else
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);

                ani.SetBool("attack", true);
                atacando = true;
            }

        }
    }
   

    void Update()
    {
        Comportamiento_Enemigo();
    }



    






    
}