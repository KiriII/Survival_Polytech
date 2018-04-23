using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest : Interaction {

    private int expAmount;

    private void Awake()
    {
        FloatingTextController.Initialize();
        expAmount = 2500;
    }

    public override void Interact()
    {
        if (Inventory.instance.items.Count >= 2)
        {
           if (gameObject !=null) Destroy(gameObject);
            FloatingTextController.CreateFloatingText("EXP +" + expAmount.ToString(), transform);
            CharacterStats.instance.EarnEXP(2500);
        }
    }
}
