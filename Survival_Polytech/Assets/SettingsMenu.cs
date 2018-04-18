using GreatArcStudios;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {

    public GameObject settingsPanel;

    private PauseManager pauseManager;

    private void Start()
    {
        pauseManager = settingsPanel.GetComponent<PauseManager>();
    }

    private void OnMouseDown()
    {
        pauseManager.setIsOpened(true);
    }
}
