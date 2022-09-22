using UnityEngine;
using TMPro;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI wordText;

    public void SetupPanel(bool isWin,string word)
    {
        if (isWin)
            titleText.text = "Completed!";
        else
            titleText.text = "Try Again!";

        wordText.text = "Word:" + word;
    }
}