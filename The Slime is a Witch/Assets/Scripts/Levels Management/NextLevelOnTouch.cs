using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NextLevelOnTouch : MonoBehaviour
{

    StateManager stateManager;
    Animator fadeAnim;


    void Start()
    {
        stateManager = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
        fadeAnim = GameObject.FindGameObjectWithTag("UI").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == "Player")
        {
            stateManager.currentState = StateManager.gameState.Win;
            fadeAnim.SetTrigger("fadeOut");
        }
    }
}
