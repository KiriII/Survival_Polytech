using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Interaction {

    public string NpcName = "???";
    public string[] dialogue;


    public string[] allAnswers;
    public int[] indexOfAnswers;

    private TupoiNPC tupoiNPC;

    private GameObject hero;
    private NavMeshAgent playerNavMesh;
    private Move playerMovement;
    private string[][] answers;
    private bool isInteracting = false;

    private void Start()
    {        
        tupoiNPC = GetComponent<TupoiNPC>();
        hero = GameObject.FindGameObjectWithTag("Player");
        playerNavMesh = hero.GetComponent<NavMeshAgent>();
        playerMovement = hero.GetComponent<Move>();
        descriptionText = NpcName;

        answers = new string[allAnswers.Length / 2][];
        for (int i = 0; i < allAnswers.Length / 2; i++)
        {
            answers[i] = new string[2];
            answers[i][0] = allAnswers[2 * i];
            answers[i][1] = allAnswers[2 * i + 1];
        }
    }

    private void LateUpdate()
    {
        if (isInteracting)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(hero.transform.position), 0.5f * Time.deltaTime); // rotation...
    }

    public override void Interact()
    {
        //DialogueSystem.Instance.AddNewMonologue(NpcName, dialogue, this);
        DialogueSystem.Instance.AddNewDialogue(NpcName, dialogue, this, answers, indexOfAnswers);
        tupoiNPC.StopWalking();
        // rotation...
        isInteracting = true;
        //
        playerNavMesh.isStopped = true;
        Debug.Log("Interacting with " + NpcName);
    }

    public override void AfterInteract()
    {
        tupoiNPC.ContinueWandering();
        playerMovement.StopFollowing();
        playerNavMesh.ResetPath();
        playerNavMesh.isStopped = false;
        isInteracting = false;
    }

    void OnMouseEnter()
    {
        if (detect != null)
        {
            description.enabled = true;
            SetText();
            ForImageSet();
        }
    }

    private void OnMouseExit()
    {
        if (detect != null)
        {
            description.enabled = false;
            RemoveText();
            ForImageRemove();
        }
    }
}
