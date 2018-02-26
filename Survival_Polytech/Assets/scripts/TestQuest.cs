using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest : interaction {

	public override void Interact()
    {
        if (Inventory.instance.items.Count >= 10)
        {
           if (gameObject !=null) Destroy(gameObject);
            CharacterStats.instance.EarnEXP(2500);
        }
    }
}
