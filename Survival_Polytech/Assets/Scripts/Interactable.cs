using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    public NavMeshAgent playerAgent;

    public float radius = 3f;

    bool isFocused = false;
    Transform player = null;
    bool isInteracted = false;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        isInteracted = false;
        this.playerAgent = playerAgent;
        this.playerAgent.stoppingDistance = 2f;
        playerAgent.destination = this.transform.position;
        
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with smth strange");
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        isInteracted = false;
    }

    public void OnDefocused()
    {
        isFocused = false;
        player = null;
        isInteracted = false;
    }

    private void Update()
    {
        if (!isInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                isInteracted = true;
            }
        }
    }
}
