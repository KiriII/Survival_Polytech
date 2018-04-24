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
        FloatingTextController.CreateFloatingText("+" + earnedEXP, GameObject.FindGameObjectWithTag("Player").transform);
        CharacterStats.Instance.Starvation(-eat);
        CharacterStats.Instance.EarnEXP(earnedEXP);

       // NoteManager.Instance.OpenNewNote("Food \n\n\n Press 'T' to win");        
    }
}
