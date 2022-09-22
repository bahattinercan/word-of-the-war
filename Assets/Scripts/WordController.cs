using UnityEngine;
using UnityEngine.UI;

public class WordController : MonoBehaviour
{
    public int currentColumn = 0;
    public int currentRow = 0;
    public Text[] text0,text1,text2,text3,text4,text5;
    public WordLists wordList;
    public Color perfectFindColor, findColor, notFindColor;
    public Player player;
    public Enemy enemy;

    private void Start()
    {
        wordList = GameObject.FindGameObjectWithTag("Word List").GetComponent<WordLists>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    public void FillTheBoxes(string yazi)
    {
        currentRow = yazi.Length-1;
        for (int i = 0; i < yazi.Length; i++)
        {
            string myChar = yazi.Substring(i, 1);
            Text text = GetText(i, currentColumn);
            text.text = myChar.ToUpper();
        }
    }

    public void RemoveTheBox() 
    {
        Text text = GetText(currentRow, currentColumn);
        text.text = " ";
        currentRow--;
    }

    public void ChangeTheColors(string yazi)
    {
        for (int i = 0; i < yazi.Length; i++)
        {
            string myChar = yazi.Substring(i, 1);
            string targetChar = wordList.mainWord.Substring(i, 1);
            if (myChar==targetChar)
            {
                PaintTextBG(i, "perfect");
            }
            else {
                for (int j = 0; j < wordList.mainWord.Length; j++)
                {
                    string mainChar = wordList.mainWord.Substring(j, 1);
                    if (myChar == mainChar && i != j)
                    {
                        PaintTextBG(i, "find");
                        break;
                    }
                    else
                    {
                        PaintTextBG(i, "notFind");
                    }
                }
            }          
        }
    }

    private void PaintTextBG(int row,string colorType="notFind")
    {
        Color color = new Color(0, 0, 0);
        switch (colorType)
        {
            case "notFind":
                color = notFindColor;
                break;
            case "perfect":
                color = perfectFindColor;
                break;
            case "find":
                color = findColor;
                break;
        }
        Text text = GetText(row, currentColumn);
        Image image = text.gameObject.transform.parent.gameObject.GetComponent<Image>();
        image.color = color;
    }

    private Text GetText(int row, int column)
    {
        switch (column)
        {
            case 0:
                return text0[row];
            case 1:
                return text1[row];
            case 2:
                return text2[row];
            case 3:
                return text3[row];
            case 4:
                return text4[row];
            case 5:
                return text5[row];
        }
        return null;
    }

    public bool HasFinded(string yazi) 
    {
        for (int i = 0; i < yazi.Length; i++)
        {
            string myChar = yazi.Substring(i, 1);
            string targetChar = wordList.mainWord.Substring(i, 1);
            if (myChar == targetChar)
            {
                return true;
            }
            else
            {
                for (int j = 0; j < wordList.mainWord.Length; j++)
                {
                    string mainChar = wordList.mainWord.Substring(j, 1);
                    if (myChar == mainChar && i != j)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public bool CanWin(string yazi)
    {
        if (yazi == wordList.mainWord)
            return true;
        return false;

    }
}
