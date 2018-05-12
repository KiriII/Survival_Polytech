using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour {

    private int level;
    public int Level
    {
        get
        {
            return level;
        }
       private set
        {
            level = value;
        }
    }

    public List<Goal> Goals { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public Item ItemReward { get; set; }
    public bool Completed { get; set; }

    private void Start()
    {
        Goals = new List<Goal>();
    }

    public void CheckGoals()
    {        
        Completed = Goals.All(g => g.Completed);
        if (Completed) GiveReward();
    }

    public void GiveReward()
    {
        CharacterStats.Instance.EarnEXP(ExperienceReward);

        if (ItemReward != null)
            Inventory.Instance.Add(ItemReward);
    }
}
