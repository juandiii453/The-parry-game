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
                player.ChangeHealth(damage);
            }
        }
        if (coll.CompareTag("parrry"))
        {
            HacerDamageAlEnemigo(); // 👈 Nombre correcto del método
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void HacerDamageAlEnemigo() // 👈 Este es el método que debes llamar
    {
        if (enemigo != null)
        {
            DatosEnemigo datos = enemigo.GetComponent<DatosEnemigo>();
            if (datos != null)
            {
                datos.health -= damage;
                datos.weekstate = true;
                datos.stuneado = true;
                enemigo.GetComponent<Animator>().SetBool("stun", true);
            }
            else
            {
                Debug.LogWarning("El objeto enemigo no tiene DatosEnemigo.");
            }
        }
        else
        {
            Debug.LogWarning("No se ha asignado el enemigo en AttackEnemy.");
        }
    }
}

