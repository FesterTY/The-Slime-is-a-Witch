using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;

    public void SetFullHealth()
    {
        currentHealth = maxHealth;
    }

    public void Harm(int _damageAmount)
    {
        currentHealth -= _damageAmount;
    }
}
