using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public int health = 100;
    private new Rigidbody rigidbody;
    public float movementSeed;
    
    
    
    public Vector2 sensitivity;
    public Transform camara;
    public bool dead;
    public HealthManager nm;

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
            dead = true;
        }
    }   
    private void UpdateMovemnet()
    {
       float hor = Input.GetAxisRaw("Horizontal");
       float ver = Input.GetAxisRaw("Vertical");

       if (hor != 0 || ver != 0) 
       {
         Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;

         rigidbody.velocity = direction * movementSeed;

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
        if (rotation.x > 90 && rotation.x < 90) {rotation.x = 90; } else 
        if (rotation.x <300 && rotation.x > 200) {rotation.x = 300; }
        
        
        camara.localEulerAngles = rotation;
      }
    }



    // Update is called once per frame
    void Update()
    {
       UpdateMovemnet();
       UpdateMouselook();
    }
}
