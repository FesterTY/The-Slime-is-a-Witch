using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StateManager : MonoBehaviour
{
    public float timeBeforeSceneRestart = 0.25f;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    private void Update()
    {
        GameOver();
    }

    protected void GameOver()
    {
        if (player.GetComponent<HealthManager>().currentHealth <= 0)
        {
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(timeBeforeSceneRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
