using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public GameObject enemigo;
    public int damage = 10;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            PlayerController player = coll.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ChangeHealth(damage); // Restar 10 de vida
            }
        }
        if (coll.CompareTag("parrry"))
        {
            enemigo.GetComponent<DatosEnemigo>().weekstate = true;
            enemigo.GetComponent<DatosEnemigo>().stuneado = true;
            enemigo.GetComponent<Animator>().SetBool("stun",true);
            gameObject.GetComponent<BoxCollider>().enabled = false;

            
        }
    }
}