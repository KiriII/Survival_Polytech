using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/EatableItem")]
public class EatableItem : Item {

    public float eat;
    public int earnedEXP;
    
   override public void Use()
    {
        Debug.Log("Eat " + name);
        removeFromInventory();
        CharacterStats.instance.Starvation(-eat);
        CharacterStats.instance.EarnEXP(earnedEXP);

        NoteManager.instance.OpenNewNote("Food \n\n\n Press 'T' to win");        
    }
}
