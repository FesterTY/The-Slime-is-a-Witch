using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    StateManager stateManager;
    HealthManager player;

    private void Awake()
    {
        stateManager = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
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
            default:
                stateManager.GameOver();
                break;
        }
    }
}
