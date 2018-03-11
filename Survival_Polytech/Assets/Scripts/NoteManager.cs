using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{

    #region Singleton

    public static NoteManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Slomalis' zapiski chini daun");
            return;
        }
        instance = this;
    }

    #endregion

    public GameObject note;
    public string text;

    //string[] allNotes;
    Text noteText;

    void Start()
    {
        noteText = note.GetComponentInChildren<Text>();
        UpdateText();
    }
        
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.T))
        {
            note.SetActive(!note.activeSelf);
        }
    }

    public void OpenNewNote(string newText)
    {
        noteText.text = newText;
        note.SetActive(true);
    }

    public void UpdateNewText(string newText)
    {
        noteText.text = newText;
    }

    public void UpdateText()
    {
        noteText.text = text;
    }
}