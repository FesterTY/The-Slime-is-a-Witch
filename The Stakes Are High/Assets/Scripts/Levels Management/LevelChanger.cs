using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    StateManager stateManager;
    Animator fadeAnim;

    private void Start()
    {
        fadeAnim = GetComponent<Animator>();
        stateManager = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
    }

    void OnFadeComplete()
    {
        // Check if the current game state is win or game over
        // State is set inside the StateManager script
        switch (stateManager.currentState)
        {
            case StateManager.gameState.Win:
                stateManager.Win();
                break;
            case StateManager.gameState.GameOver:
                stateManager.GameOver();
                break;
            // If game is neither win or game over, but level still needs changing
            default:
                stateManager.BringPlayerNextLevel();
                break;
        }
    }

    public void NextLevel()
    {
        fadeAnim.SetTrigger("fadeOut");
    }
}
