using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    GameObject player;
    Animator fadeAnim;
    HealthManager healthManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fadeAnim = GameObject.FindGameObjectWithTag("UI").GetComponent<Animator>();
        healthManager = player.GetComponent<HealthManager>();
    }

    private void Update()
    {
        CheckPlayerDie();
    }

    void CheckPlayerDie()
    {
        if (healthManager.currentHealth <= 0)
        {
            fadeAnim.SetTrigger("fadeOut");
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
