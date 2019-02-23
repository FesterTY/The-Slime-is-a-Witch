using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;

    private void Awake()
    {
        SetFullHealth();
    }

    private void Update()
    {
        Die();
    }

    public void SetFullHealth()
    {
        currentHealth = maxHealth;
    }

    public void Harm(int _damageAmount)
    {
        currentHealth -= _damageAmount;
        Debug.Log(currentHealth);
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
