using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interaction : MonoBehaviour {

    public Transform interactTransform; // для того чтобы описать случай, когда место взаимодействия и объект в разных местах, можно оставить сам объект
    public GameObject detect;
    public Text text;
    public Image description;
    public string descriptionText = "Не забудь добавить описание";

    public float radius = 3f;
    bool isFocused = false;
    Transform player = null;
    bool isInteracted = false;

    public virtual void Interact()
    {

    }

    public virtual void ForImageSet()
    {

    } 

    public virtual void ForImageRemove()
    {

    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        isInteracted = false;
    }

    public void OnDefocused()
    {
        isFocused = false;
        player = null;
        isInteracted = false;
    }
    
    void OnMouseEnter()
    {
        detect.GetComponent<MeshRenderer>().enabled = true;
        description.enabled = true;
        SetText();
        ForImageSet();
    }

    private void OnMouseExit()
    {
        detect.GetComponent<MeshRenderer>().enabled = false;
        description.enabled = false;
        RemoveText();
        ForImageRemove();
    }

    public virtual void SetText()
    {
        text.text = descriptionText;
        text.enabled = true;
    }

    public void RemoveText()
    {
        text.text = null;
        text.enabled = false;
    }

    private void Update()
    {
        if(isFocused && !isInteracted )
        {
            float distanse = Vector3.Distance(player.transform.position, interactTransform.position);
            if(distanse <= radius)
            {
                Interact();
                isInteracted = true;
            }
        }
      
    }

    
}
