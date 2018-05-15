using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeIsLife : Quest {

    public Transform goalPosition;

    void Start()
    {
        Debug.Log("Coffee rush!");
        QuestName = "Coffee is your life";
        Description = "Try not to fall asleep";
        //ItemReward = ItemDatabase.Instance.GetItem(" ");
        ExperienceReward = 450;
        Goals = new List<Goal>
        {
            new DestinationGoal(this, goalPosition.position, "Find cafe", false, 0, 1),
            new CollectionGoal(this, "coffee_1", "Take coffee", false, 0, 1)
            //new CoffeeGoal(this, 1, "Drink some coffee", false, 0, 2)
        };

        Goals.ForEach(g => g.Init());
    }
}
