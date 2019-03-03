using UnityEngine;

public class Carrot : MonoBehaviour
{
    public GameObject whoCanCollect;
    public CollectibleManager carrotManager;

    AudioManager audioManager;
    AudioSource collectEffect;

    private void Start()
    {
        carrotManager = GameObject.FindGameObjectWithTag("CarrotManager").GetComponent<CollectibleManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        if (audioManager != null)
        {
            collectEffect = GameObject.Find("CollectEffect").GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.tag == whoCanCollect.tag)
        {
            audioManager.PlayEffect(collectEffect);
            carrotManager.AddToCollection();
            Collected();
        }
    }

    void Collected()
    {
        Destroy(gameObject);
    }
}
