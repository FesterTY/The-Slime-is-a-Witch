using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public void UpdateText(Text textToUpdate, string whatToUpdate)
    {
        textToUpdate.text = whatToUpdate;
    }
}
