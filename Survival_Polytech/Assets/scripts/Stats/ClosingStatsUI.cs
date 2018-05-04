using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingStatsUI : MonoBehaviour {

	public GameObject Panel;
	private Animator anime;
	private bool isOpened;
	public string openAnim;
	public string closeAnim;
	public string StringKeyCode;
	private KeyCode kc;

	// Use this for initialization
	void Start () {
		Panel.gameObject.SetActive (false);
		anime = Panel.GetComponent<Animator> ();
		anime.enabled = false;
		kc = (KeyCode)System.Enum.Parse (typeof(KeyCode), StringKeyCode);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (kc) && !isOpened) {
			OpenMenu ();
		} else if (Input.GetKeyDown (kc) && isOpened) {
			CloseMenu ();
		}
	}

	public void OpenMenu() {
		Panel.gameObject.SetActive (true);
		anime.enabled = true;	
		anime.Play (openAnim);
		StartCoroutine (WaitForOpen ());
	}

	public void CloseMenu() {
		anime.Play (closeAnim);
		StartCoroutine (WaitForClose ());
	}

	private IEnumerator WaitForOpen() {
		yield return new WaitForSeconds (1);
		isOpened = true;
	}

	private IEnumerator WaitForClose() {
		yield return new WaitForSeconds (1);
		Panel.gameObject.SetActive (false);
		isOpened = false;
	}
}