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

    Interaction talker;

	
	void Awake () {
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
	
	public void AddNewDialogue(string npcName, string[] lines)
    {
        dialogueIndex = 0;
        this.npcName = npcName;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        CreateDialogue();
    }

    public void AddNewDialogue(string npcName, string[] lines, Interaction talker)
    {
        dialogueIndex = 0;
        this.talker = talker;
        this.npcName = npcName;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        nameText.text = npcName;
        dialogueText.text = dialogueLines[dialogueIndex];
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
      if (dialogueIndex <dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
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
