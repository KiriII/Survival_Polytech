using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject settingsMenu;

    float timeScale = 1f;

    private void Awake()
    {
        Time.timeScale = 1;
        settingsMenu.SetActive(true);
    }

    void Start()
    {        
        settingsMenu.SetActive(false);
    }
       
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsMenu.SetActive(!settingsMenu.activeSelf);
            if (settingsMenu.activeSelf) Time.timeScale = 0;
            else Time.timeScale = timeScale;
        }
    }
}
