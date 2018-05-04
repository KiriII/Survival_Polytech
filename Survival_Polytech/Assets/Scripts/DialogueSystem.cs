using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance { get; set; }

    public GameObject dialoguePanel;

    [HideInInspector]
    public string npcName = "???";
    [HideInInspector]
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    string[][] answers;
    int[] indexOfAnswerArray;
    int indexOfAnswer;
    bool answering;

    Interaction talker;

	
	void Awake () {
        answering = false;

        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}
	
	public void AddNewMonologue(string npcName, string[] lines)
    {
        this.dialogueIndex = 0;
        this.npcName = npcName;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        CreateDialogue();
    }

    public void AddNewMonologue(string npcName, string[] lines, Interaction talker)
    {
        this.dialogueIndex = 0;
        this.talker = talker;
        this.npcName = npcName;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        
        CreateDialogue();
    }

    public void AddNewDialogue(string npcName, string[] lines, string[][] answers, int[] indexOfAnswer)
    {
        this.dialogueIndex = 0;
		this.indexOfAnswer = 0;
        this.npcName = npcName;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        this.answers = answers;
        this.indexOfAnswerArray = indexOfAnswer;
        this.indexOfAnswer = 0;

        CreateDialogue();
        CheckAnswerRequirement();
    }

    public void AddNewDialogue(string npcName, string[] lines, Interaction talker, string[][] answers, int[] indexOfAnswers)
    {
        this.dialogueIndex = 0;
		this.indexOfAnswer = 0;
        this.talker = talker;
        this.npcName = npcName;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        this.answers = answers;
        this.indexOfAnswerArray = indexOfAnswers;
        this.indexOfAnswer = 0;

        CreateDialogue();
        CheckAnswerRequirement();
    }

    public void CreateDialogue()
    {
        nameText.text = npcName;
        dialogueText.text = dialogueLines[dialogueIndex];
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (!answering)
        {
            if (dialogueIndex < dialogueLines.Count - 1)
            {
                dialogueIndex++;
                dialogueText.text = dialogueLines[dialogueIndex];

                CheckAnswerRequirement();
            }
            else
            {
                if (talker != null)
                {
                    talker.AfterInteract();
                    talker = null;
                }
                dialoguePanel.SetActive(false);
                Debug.Log("End of converstion");
            }
        }
    }

    private void CheckAnswerRequirement()
    {
        if (indexOfAnswer < indexOfAnswerArray.Length)
        {
            if (dialogueIndex == indexOfAnswerArray[indexOfAnswer])
            {
                CreateAnswer(answers[indexOfAnswer]);
                indexOfAnswer++;
            }
        }
    }

    public void CreateAnswer(string[] answerLines)
    {
        AnsweringSystem.Instance.AddNewAnswer(answerLines);
        answering = true;
        continueButton.interactable = false;
    }

    public void EndAnswer(int answerIndex)
    {
        answering = false;
        continueButton.interactable = true;
        // разветвление диалога (answerIndex)
        dialogueIndex += answerIndex; // простое разветвление
        ContinueDialogue();
    }
}
