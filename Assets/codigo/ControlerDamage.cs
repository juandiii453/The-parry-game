using UnityEngine;

public class ControlerDamage : MonoBehaviour
{
    [SerializeField] private AttackEnemy damageScript;  // Referencia a tu script AttackEnemy

    // Método para aplicar daño al enemigo asignado en AttackEnemy
    public void AplicarDamage()
    {
        if (damageScript != null)
        {
            
            damageScript.HacerDamageAlEnemigo();
        }
        else
        {
            Debug.LogWarning("No se ha asignado el script AttackEnemy en ControlerDamage.");
        }
    }
}
