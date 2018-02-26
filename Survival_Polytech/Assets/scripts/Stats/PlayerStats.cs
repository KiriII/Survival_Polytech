using System.Collections;
using UnityEngine;
//using stats;

public class PlayerStats : MonoBehaviour  {

   // public CharacterStats stats = new CharacterStats(100, 1, 999, 80, 30, 100, 50, 50, 50);
    public static bool alive = true;
    public bool showStats;
    public int lvlUpPoints = 0; 


	void Start () {
        alive = true;
	}



	
    /* нужен отдельный клаас предметов (Equipment) 
	void OnEquipmentChanged(Item newItem, Item oldItem)
    {
        if(newItem != null)
        {
            // change stats  (smth.AddModifier)
        }
    }
    */
}
