using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interaction {

    public string Name;
    public string[] dialogue;

    private TupoiNPC tupoiNPC;

    private void Start()
    {
        tupoiNPC = GetComponent<TupoiNPC>();
    }

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(Name, dialogue, this);
        tupoiNPC.StopWalking();
        Debug.Log("Interacting with NPC");
    }

    public override void AfterInteract()
    {
        tupoiNPC.ContinueWandering();
    }

    void OnMouseEnter()
    {
        
    }

    private void OnMouseExit()
    {
        
    }
}
