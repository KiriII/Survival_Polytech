using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    public delegate void OnItemChangedHandler(Item item);
    public static OnItemChangedHandler OnItemAddedToInventory;
    public static OnItemChangedHandler OnItemRemovedFromInventory;

    public delegate void PlayerHealthEventHandler(int currentHealth);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChange;

    public static void ItemAddedToInventory(Item item)
    {
        if (OnItemAddedToInventory != null)
        {
            OnItemAddedToInventory.Invoke(item);
        }
    }

    public static void ItemRemovedFromInventory(Item item)
    {
        if (OnItemRemovedFromInventory != null)
        {
            OnItemRemovedFromInventory.Invoke(item);
        }
    }

    public static void HealthChanged(int currentHealth)
    {
        if (OnPlayerHealthChanged != null)
            OnPlayerHealthChanged(currentHealth);
    }

    public static void PlayerLevelChanged()
    {
        if (OnPlayerLevelChange != null)
            OnPlayerLevelChange();
    }
}
