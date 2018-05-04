using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosingStats : MonoBehaviour {


	private int maxHealth;
	private float currentHealth;
	private int lvl;
	private float ExpToLvlUp;
	private float EXP;
	private float money;
	private float hunger;
	private float sleepiness;
	private int sanity;
	private int intelligence;
	private int agility;
	private int authority;


	Text text;
	public Text currentHealthT;
	public Text moneyT;
	public Text sanityT;
	public Text EXPT;
	public Text lvlT;
	public Text agilityT;
	public Text authorityT;
	public Text intelligenceT;
	public Text hungerT;
	public Text sleepinessT;

	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		maxHealth = CharacterStats.Instance.maxHealth;
		currentHealth = CharacterStats.Instance.currentHealth;
		lvl = CharacterStats.Instance.lvl;
		ExpToLvlUp = CharacterStats.Instance.ExpToLvlUp;
		EXP = CharacterStats.Instance.EXP;
		money = CharacterStats.Instance.money;
		hunger = CharacterStats.Instance.hunger;
		sleepiness = CharacterStats.Instance.sleepiness;
		sanity = CharacterStats.Instance.sanity;
		intelligence = CharacterStats.Instance.intelligence;
		agility = CharacterStats.Instance.agility;
		authority = CharacterStats.Instance.authority;
	}
	
	// Update is called once per frame
	void Update () {
		maxHealth = CharacterStats.Instance.maxHealth;
		currentHealth = CharacterStats.Instance.currentHealth;
		lvl = CharacterStats.Instance.lvl;
		ExpToLvlUp = CharacterStats.Instance.ExpToLvlUp;
		EXP = CharacterStats.Instance.EXP;
		money = CharacterStats.Instance.money;
		hunger = CharacterStats.Instance.hunger;
		sleepiness = CharacterStats.Instance.sleepiness;
		sanity = CharacterStats.Instance.sanity;
		intelligence = CharacterStats.Instance.intelligence;
		agility = CharacterStats.Instance.agility;
		authority = CharacterStats.Instance.authority;
		ExpToLvlUp = CharacterStats.Instance.ExpToLvlUp;
		currentHealthT.text = "Health " + currentHealth + "/" + maxHealth;
		lvlT.text = "Level: " + lvl;
		EXPT.text = "EXP " + EXP + "/" + ExpToLvlUp;
		moneyT.text = "Money " + money;
		hungerT.text = "Hunger " + hunger;
		sleepinessT.text = "sleepiness " + sleepiness;
		sanityT.text = "sanity " + sanity;
		intelligenceT.text = "intelligence " + intelligence;
		agilityT.text = "agility " + agility;
		authorityT.text = "authority " + authority;

		
	}
}
