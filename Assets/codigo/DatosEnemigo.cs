using System;
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

    public event EventHandler MuerteEnemigo;

    // Tiempo entre ataques
    public float tiempoEntreAtaques = 2f;
    private float tiempoDesdeUltimoAtaque = 0f;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("parry");
    }

    void Update()
    {
        Comportamiento_Enemigo();
        health_dead();
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        stuneado = false;
        weekstate = false;
    }

    public void health_dead()
    {
        if (health <= 0)
        {
            MuerteEnemigo?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
            FindObjectOfType<SpawnEnemies>().Enemy_dead();
        }
    }

    public void Comportamiento_Enemigo()
    {
        if (target == null)
        {
            target = GameObject.Find("parry");
            if (target == null) return;
        }

        float distancia = Vector3.Distance(transform.position, target.transform.position);

        if (distancia > 50)
        {
            ani.SetBool("run", false);
            cronometro += Time.deltaTime;

            if (cronometro >= 4)
            {
                rutina = UnityEngine.Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = UnityEngine.Random.Range(0f, 360f);
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
                Vector3 lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 7 * Time.deltaTime);
                ani.SetBool("attack", false);

                tiempoDesdeUltimoAtaque = tiempoEntreAtaques;
            }
            else
            {
                if (!stuneado)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);

                    tiempoDesdeUltimoAtaque += Time.deltaTime;

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
}



