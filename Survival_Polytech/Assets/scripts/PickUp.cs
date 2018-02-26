using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : interaction {

    public Image takeble;
    public Item item;

	public override void Interact()
    {
        base.Interact(); // берет всё из оригинала
       
        Take();
    }

    public override void ForImageSet()
    {
        takeble.enabled = true;
    }

    public override void ForImageRemove()
    {
        takeble.enabled = false;
    }

    void Take()
    {
       bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
           ForImageRemove();
           description.enabled = false;
           text.enabled = false;
           RemoveText();
           Destroy(gameObject);
        }
    }
}
