using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Interaction {

    public string NpcName;
    public string[] dialogue;

    private TupoiNPC tupoiNPC;

    private GameObject hero;
    private NavMeshAgent playerNavMesh;
    private Move playerMovement;

    private void Start()
    {        
        tupoiNPC = GetComponent<TupoiNPC>();
        hero = GameObject.FindGameObjectWithTag("Player");
        playerNavMesh = hero.GetComponent<NavMeshAgent>();
        playerMovement = hero.GetComponent<Move>();
        descriptionText = NpcName;
    }

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(NpcName, dialogue, this);
        tupoiNPC.StopWalking();
        // rotation...
        playerNavMesh.isStopped = true;
        Debug.Log("Interacting with " + NpcName);
    }

    public override void AfterInteract()
    {
        tupoiNPC.ContinueWandering();
        playerMovement.StopFollowing();
        playerNavMesh.ResetPath();
        playerNavMesh.isStopped = false;
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
