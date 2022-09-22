using System.Collections.Generic;
using UnityEngine;

public class WordLists : MonoBehaviour
{
    public List<string> words;
    public string mainWord;

    private void Start()
    {
        int index = Random.Range(0, words.Count);
        string geciciWord = words[index].ToUpper();
        for (int i = 0; i < geciciWord.Length; i++)
        {
            if (geciciWord.Substring(i, 1) == "Ý")
                mainWord += "I";
            else
                mainWord += geciciWord.Substring(i, 1);
        }
        GameController.instance.TargetWord = mainWord;
    }
}