using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    GameObject player;
    Animator fadeAnim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fadeAnim = GameObject.FindGameObjectWithTag("UI").GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerDie();
    }

    void PlayerDie()
    {
        if (player.GetComponent<HealthManager>().currentHealth <= 0)
        {
            fadeAnim.SetTrigger("fadeOut");
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
