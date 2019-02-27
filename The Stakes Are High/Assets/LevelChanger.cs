using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    StateManager stateManager;

    private void Awake()
    {
        stateManager = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();    
    }

    void OnFadeComplete()
    {
        stateManager.GameOver();
    }
}
