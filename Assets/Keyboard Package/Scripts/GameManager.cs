using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public InputField TextField;
    public static GameManager Instance;
    public WordController wordController;
    public bool canWrite;
    public int waitTime;

    private void Awake()
    {
        Instance = this;
    }

    public void DeleteLetter()
    {
        if (TextField.text.Length > 0)
        {
            TextField.text = TextField.text.Remove(TextField.text.Length - 1);
            if (wordController.currentRow > -1)
                wordController.RemoveTheBox();
        }
    }

    public void AddLetter(string letter)
    {
        if (TextField.text.Length < 5)
        {
            if (canWrite)
            {
                TextField.text = TextField.text + letter;
                if (TextField.text != "")
                    wordController.FillTheBoxes(TextField.text);
            }
        }
        string word = TextField.text;
        if (TextField.text.Length == 5 && canWrite)
        {
            wordController.ChangeTheColors(word);
            wordController.currentRow = -1;
            if (wordController.CanWin(word))
            {
                GameController.instance.WinTheGame();
                wordController.player.FinishedAttack();
                canWrite = false;
            }
            else
            {
                if (wordController.HasFinded(word) && wordController.currentColumn != 5)
                {
                    wordController.player.NormalAttack();
                }
                else
                {
                    if (wordController.currentColumn == 5)
                        wordController.enemy.FinisherAttack();
                    else
                        wordController.enemy.NormalAttack();
                }
                TextField.text = "";
                wordController.currentColumn++;
                canWrite = false;
                StartCoroutine(WriteCo());
            }

        }
    }

    public void SubmitWord()
    {

    }

    public IEnumerator WriteCo()
    {
        yield return new WaitForSeconds(waitTime);
        canWrite = true;
    }
}
