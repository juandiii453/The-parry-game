using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    private new Rigidbody rigidbody;

    public float velocidadNormal = 3f;

    public Vector2 sensitivity;
    public Transform camara;
    public bool dead;
    public HealthManager nm;

    public event EventHandler MuerteJugador;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ChangeHealth(int count)
    {
        health -= count;
        nm.SetHealth(health);
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
        }
    }

    private void UpdateMovemnet()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;
            rigidbody.velocity = direction * velocidadNormal;
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    private void UpdateMouselook()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0)
        {
            transform.Rotate(0, hor * sensitivity.x, 0);
        }

        if (ver != 0)
        {
            Vector3 rotation = camara.localEulerAngles;
            rotation.x = (rotation.x - ver * sensitivity.y + 360) % 360;

            if (rotation.x > 90 && rotation.x < 270) rotation.x = 90;
            if (rotation.x < 300 && rotation.x > 180) rotation.x = 300;

            camara.localEulerAngles = rotation;
        }
    }

    void Update()
    {
        UpdateMovemnet();
        UpdateMouselook();
    }
}

