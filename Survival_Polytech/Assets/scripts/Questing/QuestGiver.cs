﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC {

    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;
    private Quest Quest { get; set; }
    public override void Interact()
    {

        if (!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewMonologue(name, new string[] { "Nothing more for you." }, this);
           // DialogueSystem.Instance.AddNewDialogue(NpcName, dialogue, this, Answers, indexOfAnswers);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewMonologue(name, new string[] { "Thanks for that! Here's your reward.", "More dialogue.." }, this);
        }
        else
        {
            DialogueSystem.Instance.AddNewMonologue(name, new string[] { "You're still in the middle of helping me. Get back at it!" }, this);
        }
    }
}
