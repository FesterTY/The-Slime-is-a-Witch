using UnityEngine;

public class RestartLevelOnTouch : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            HealthManager healthManager = _collision.GetComponent<HealthManager>();

            // Harming by the current health gets the player's health to 0
            healthManager.Harm(healthManager.currentHealth);
        }
    }

}
