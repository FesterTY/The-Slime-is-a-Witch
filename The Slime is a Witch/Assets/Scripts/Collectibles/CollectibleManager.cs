using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    int collected = 0;
    int numOfCollectiblesInScene = 0;
    Text collectibleText;

    public string collectibleTag;
    public string textCounterName;

    private void Start()
    {
        // Get all collectibles from the scene upon the object being initialized
        numOfCollectiblesInScene = GameObject.FindGameObjectsWithTag(collectibleTag).Length;

        collectibleText = GameObject.FindGameObjectWithTag(textCounterName).GetComponent<Text>();
    }

    void Update()
    {
        collectibleText.text = collected.ToString() + "/" + numOfCollectiblesInScene.ToString();
    }

    public void AddToCollection()
    {
        collected++;
    }
}
