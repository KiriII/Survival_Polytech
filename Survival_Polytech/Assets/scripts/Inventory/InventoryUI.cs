using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventiryUI;

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCalledBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}


	void Update () {
        if (Input.GetButtonDown("inventory"))
        {
            inventiryUI.SetActive(!inventiryUI.activeSelf);
        }
		
	}

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
