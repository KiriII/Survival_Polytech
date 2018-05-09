using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsweringSystem : MonoBehaviour {
    public static AnsweringSystem Instance { get; set; }

    public GameObject answerPanel;
    public GameObject choice1, choice2;

    [HideInInspector]
    public List<string> answerLines = new List<string>();

    Button choiceButton1;
    Button choiceButton2;
    Text answerText1, answerText2;

    Interactable talker;


    void Awake()
    {
        choiceButton1 = choice1.GetComponentInChildren<Button>();
        choiceButton1.onClick.AddListener(delegate { ContinueDialogue(0); });

        choiceButton2 = choice2.GetComponentInChildren<Button>();
        choiceButton2.onClick.AddListener(delegate { ContinueDialogue(1); });

        answerText1 = choice1.GetComponentInChildren<Text>();
        answerText2 = choice2.GetComponentInChildren<Text>();

        answerPanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewAnswer(string[] lines)
    {

        answerLines = new List<string>(lines.Length);
        answerLines.AddRange(lines);
        Debug.Log("new answer");
        CreateAnswer();
    }

    public void CreateAnswer()
    {
        answerText1.text = answerLines[0];
        answerText2.text = answerLines[1];
        answerPanel.SetActive(true);
    }

    public void ContinueDialogue(int answerIndex)
    {
        answerPanel.SetActive(false);
        Debug.Log("End of answer");
		DialogueSystem.Instance.EndAnswer(answerIndex);
    }
}
