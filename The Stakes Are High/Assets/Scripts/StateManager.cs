using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    GameObject player;
    Animator fadeAnim;
    HealthManager healthManager;
    GameObject gameManager;

    [HideInInspector]
    public gameState currentState;

    public enum gameState
    {
        Win,
        GameOver,
        Neutral,
        GameFinished
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        fadeAnim = GameObject.FindGameObjectWithTag("UI").GetComponent<Animator>();

        if (player != null)
        {
            healthManager = player.GetComponent<HealthManager>();
        }
    }

    private void Update()
    {
        if (healthManager != null)
        {
            CheckPlayerDie();
        }
    }

    void CheckPlayerDie()
    {
        if (healthManager.currentHealth <= 0)
        {
            currentState = gameState.GameOver;
            fadeAnim.SetTrigger("fadeOut");
        }
    }

    public void SetState(gameState gameState)
    {
        currentState = gameState;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        Neutral();
    }

    public void Neutral()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(gameManager);
    }

    public void GameFinished()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
