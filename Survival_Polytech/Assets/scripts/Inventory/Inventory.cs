﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Slomalsya inventar' chini daun");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCalledBack;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add ( Item item )
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory more than full idiot");
                return false;
            }
            
                items.Add(item);

                if (onItemChangedCalledBack != null)
                {
                    onItemChangedCalledBack.Invoke();
                }
                    }
        return true;
    }

    public void Remove( Item item )
    {
        items.Remove(item);

        if (onItemChangedCalledBack != null)
        {
            onItemChangedCalledBack.Invoke();
        }
    }
}
