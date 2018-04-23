using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour {

	public Image healthI;
	public Image hungerI;
	public Image sanityI;
	public Image expI;

	private float currentHp;
	private float maximumHp;
	private float sanity;
	private float exp;
	private float hunger;
	private float maxValue;

	GameObject hero;
	CharacterStats characterStats;

	// Use this for initialization
	void Start () {
		hero = GameObject.FindGameObjectWithTag("Player");
		characterStats = hero.GetComponent<CharacterStats>();

        maxValue = characterStats.getMaxValue();
		maximumHp = characterStats.maxHealth;
		currentHp = characterStats.currentHealth;
		sanity = characterStats.sanity;
		exp = characterStats.EXP;

		setup();
	}

	// Update is called once per frame
	void Update () {
		if (currentHp != characterStats.currentHealth) {
			currentHp = characterStats.currentHealth;
			healthI.transform.localScale = new Vector2((currentHp / maximumHp),(float) healthI.transform.localScale.y);
		}

		if (hunger != characterStats.hunger) {
			hunger = characterStats.hunger;
			hungerI.transform.localScale = new Vector2((hunger / maxValue),(float) hungerI.transform.localScale.y);
		}

		if (sanity != characterStats.sanity) {
			
			sanityI.transform.localScale = new Vector2((sanity / maxValue),(float) sanityI.transform.localScale.y);
		}

		if (exp != characterStats.EXP) {
			exp = characterStats.EXP;
			expI.transform.localScale = new Vector2((exp / characterStats.ExpToLvlUp),(float) expI.transform.localScale.y);
		}
	}

	void setup() {
		healthI.transform.localScale = new Vector2((currentHp / maximumHp),(float) healthI.transform.localScale.y);
		hungerI.transform.localScale = new Vector2((hunger / maxValue),(float) hungerI.transform.localScale.y);
		sanityI.transform.localScale = new Vector2((sanity / maxValue),(float) sanityI.transform.localScale.y);
		expI.transform.localScale = new Vector2((exp / characterStats.ExpToLvlUp),(float) expI.transform.localScale.y);
	}
}