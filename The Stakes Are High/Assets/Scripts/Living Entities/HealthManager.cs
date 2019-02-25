using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : StateManager
{
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;

    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;

    public Text healthText;

    CameraShake camShake;

    private void Awake()
    {
        SetFullHealth();
        camShake = Camera.main.GetComponent<CameraShake>();
    }

    public void SetFullHealth()
    {
        currentHealth = maxHealth;
    }

    public void Harm(float _damageAmount)
    {
        currentHealth -= _damageAmount;

        camShake.StartShake(shakeDuration, shakeMagnitude);

        if (gameObject.tag == "Player")
        {
            healthText.text = currentHealth.ToString();
        }

        CheckDie();
    }

    protected void CheckDie()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
