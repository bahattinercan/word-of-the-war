using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardScript : MonoBehaviour
{
    public InputField TextField;
    public GameObject RusLayoutSml, RusLayoutBig, EngLayoutSml, EngLayoutBig, SymbLayout;
    public WordController wordController;
    public bool canWrite;
    public int waitTime;

    private void Start()
    {
        canWrite = true;
        wordController = GameObject.FindGameObjectWithTag("Word Controller").GetComponent<WordController>();
    }

    public void alphabetFunction(string alphabet)
    {

        if (TextField.text.Length < 5)
        {
            if (canWrite)
            {
                TextField.text = TextField.text + alphabet;
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

    public IEnumerator WriteCo()
    {
        yield return new WaitForSeconds(waitTime);
        canWrite = true;
    }

    public void BackSpace()
    {
        if (TextField.text.Length > 0)
        {
            TextField.text = TextField.text.Remove(TextField.text.Length - 1);
            if (wordController.currentRow > -1)
                wordController.RemoveTheBox();
        }

    }

    public void CloseAllLayouts()
    {
        RusLayoutSml.SetActive(false);
        RusLayoutBig.SetActive(false);
        EngLayoutSml.SetActive(false);
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);
    }

    public void ShowLayout(GameObject SetLayout)
    {
        CloseAllLayouts();
        SetLayout.SetActive(true);
    }
}