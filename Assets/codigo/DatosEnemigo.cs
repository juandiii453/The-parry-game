using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosEnemigo : MonoBehaviour
{
    public int health = 100;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public bool weekstate;

    public GameObject target;
    public bool atacando;

    public GameObject arma;
    public bool stuneado;

    private float cronometro;
    private int rutina;

    // Tiempo entre ataques
    public float tiempoEntreAtaques = 2f;
    private float tiempoDesdeUltimoAtaque = 0f;

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        stuneado = false;
        weekstate = false;
    }

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("parry");
    }

    public void Comportamiento_Enemigo()
    {
        if (target == null)
        {
            GameObject nuevoTarget = GameObject.Find("parry");
            if (nuevoTarget != null)
            {
                target = nuevoTarget;
            }
            else
            {
                return;
            }
        }

        float distancia = Vector3.Distance(transform.position, target.transform.position);

        if (distancia > 50)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 3 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (distancia > 5)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 7 * Time.deltaTime);
                ani.SetBool("attack", false);

                // Reinicia temporizador si está fuera del rango de ataque
                tiempoDesdeUltimoAtaque = tiempoEntreAtaques;
            }
            else
            {
                if (!stuneado)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);

                    // Aumentar el tiempo desde el último ataque
                    tiempoDesdeUltimoAtaque += Time.deltaTime;

                    // Ataca solo si pasó el tiempo necesario
                    if (tiempoDesdeUltimoAtaque >= tiempoEntreAtaques)
                    {
                        ani.SetBool("attack", true);
                        atacando = true;
                        tiempoDesdeUltimoAtaque = 0f;
                    }
                }
            }
        }
    }

    public void ColliderWeaponTrue()
    {
        if (arma != null)
            arma.GetComponent<BoxCollider>().enabled = true;
    }

    public void ColliderWeaponFalse()
    {
        if (arma != null)
            arma.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
}


