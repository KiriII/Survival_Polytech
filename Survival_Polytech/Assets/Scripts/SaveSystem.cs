using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class SaveSystem : MonoBehaviour {

    #region Singleton

    public static SaveSystem Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Slomalis' saves chini daun");
            return;
        }
        Instance = this;
    }

    #endregion 

    public GameObject hero;
    public GameObject[] npc;

    [HideInInspector]
    public Save sv = new Save();
    private string path;

    private void Start()
    {
        path = Path.Combine(Application.dataPath, "Save.json");

        LoadFromLastSave();
    }

    public void LoadFromLastSave()
    {
        Debug.Log("Start loading last save");
        if (PlayerPrefs.HasKey("Save"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
            Debug.Log("Последнее сохранение загружено!");

            hero.GetComponent<NavMeshAgent>().ResetPath();
            hero.GetComponent<Transform>().position = new Vector3(sv.positionX,sv.positionY, sv.positionZ);

           //hero.GetComponent<CharacterStats>() = sv.characterStats;
        }
        else
        {
            Debug.Log("Сохранений нет, а возможно ты просто лох");
        }
        
    }

    public void SaveLastState()
    {
        Debug.Log("Start saving");

        sv.positionX = hero.GetComponent<Transform>().position.x;
        sv.positionY = hero.GetComponent<Transform>().position.y;
        sv.positionZ = hero.GetComponent<Transform>().position.z;
        
        //sv.characterStats = hero.GetComponent<CharacterStats>().getAllStats();

        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveLastState();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromLastSave();
        }
    }

    private void OnApplicationQuit()
    {
        SaveLastState();
        
        Debug.Log("Game was automaticaly saved on exit");
        File.WriteAllText(path, JsonUtility.ToJson(sv));       // резерв
    }
}
[Serializable]
public class Save
{   
    public float positionX;
    public float positionY;
    public float positionZ;

    public float[] characterStats;

    public List<GameObject> objectsToDel;
    public List<GameObject> objectsToCreate;
    public List<GameObject> objectsInInventory;
    public List<Transform> npcPositions;
}
