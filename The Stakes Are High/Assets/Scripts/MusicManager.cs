using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager instance;

    private void Awake()
    {
        CheckInstance();
    }

    void CheckInstance()
    {
        // This gets check with every MusicManager
        // UNLIKE LOCALS, THE GLOBAL INSTANCE WILL ONLY CHECK ONCE ON AWAKE

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }
}
