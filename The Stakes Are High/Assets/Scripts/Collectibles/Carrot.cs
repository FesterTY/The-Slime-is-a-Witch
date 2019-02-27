using UnityEngine;

public class Carrot : MonoBehaviour
{
    public GameObject whoCanCollect;
    public CollectibleManager carrotManager;

    private void Start()
    {
        carrotManager = GameObject.FindGameObjectWithTag("CarrotManager").GetComponent<CollectibleManager>();    
    }

    void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == whoCanCollect.tag)
        {
            carrotManager.AddToCollection();
            Collected();
        }
    }

    void Collected()
    {
        Destroy(gameObject);
    }
}
