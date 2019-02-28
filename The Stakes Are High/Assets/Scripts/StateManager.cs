using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    GameObject player;
    Animator fadeAnim;
    HealthManager healthManager;

    [HideInInspector]
    public gameState currentState;

    public enum gameState
    {
        Win,
        GameOver
    }

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
            currentState = gameState.GameOver;
            fadeAnim.SetTrigger("fadeOut");
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
