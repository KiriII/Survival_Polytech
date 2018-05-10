using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thinking : MonoBehaviour {   

    #region Singleton

    public static Thinking Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Slomalis' misli chini daun");
            return;
        }
        Instance = this;
    }
    #endregion 

    public bool forDoor = false;

    private float time = 5f;

    private void Update()
    {
        if (forDoor == true)
        {
            gameObject.GetComponent<TextMesh>().text = "Похоже здесь не пройти";
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                Debug.Log("СХС");
                forDoor = false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<TextMesh>().text = "Это не должно здесь быть";
            }
        }
    }
}
