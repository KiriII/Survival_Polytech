using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationGoal : Goal {

    private Vector3 goalPosition;

    public DestinationGoal(Quest quest, Vector3 _goalPosition, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.goalPosition = _goalPosition;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        // UIEventHandler.OnItemAddedToInventory += ItemPickedUp;
    }    

    void CheckPosition(Vector3 eventPos)
    {

    }

    void DestinationReached()
    {

    }
}
