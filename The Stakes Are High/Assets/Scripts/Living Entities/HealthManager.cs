using UnityEngine;

public class HealthManager : StateManager
{
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;

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

    public void Harm(float _damageAmount)
    {
        currentHealth -= _damageAmount;
        Debug.Log(currentHealth);
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            if (gameObject.tag == "Player")
            {
                PlayerDie();
            }
        }
    }

    private void PlayerDie()
    {
        GameOver();
    }
}
