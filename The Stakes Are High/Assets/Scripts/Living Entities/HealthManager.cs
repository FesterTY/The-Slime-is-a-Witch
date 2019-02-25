using UnityEngine;
using UnityEngine.UI;

public class HealthManager : StateManager
{
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;

    public Text healthText;

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

        if (gameObject.tag == "Player")
        {
            healthText.text = currentHealth.ToString();
        }
    }

    protected void Die()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
