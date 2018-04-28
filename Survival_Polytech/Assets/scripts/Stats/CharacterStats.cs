using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    #region Singleton

    public static CharacterStats Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Slomalis' stati chini daun");
            return;
        }
        Instance = this;
    }

    #endregion
   

    private bool alive = true;
    private bool sleeping = false;
    private bool starvation = false;

    public bool showStats;

    [Range(0, 200)]
    public int maxHealth = 100;
    public float currentHealth { get; private set; }
    public int lvl;
    private int lvlUpPoints;
    public float ExpToLvlUp;
    public float EXP;
    public float money;

    [Range(1, 300)]
    public float maxValue = 100f;
    [Range(0, 300)]
    public float hunger;
    public float constOfHunger;
    public float hungerDyingConst;
    [Range(0, 300)]
    public float sleepiness;
    public float constOfSleepiness;
    [Range(0, 300)]
    public int sanity;

    public int intelligence;
    public int agility;
    public int authority;
      
  
    private void Start()
    {
        alive = true;
        showStats = false;
        currentHealth = maxHealth;
		//maxValue = 100;
    }

    private void FixedUpdate()
    {
        if (alive)
        {
            FallingAsleep(constOfSleepiness);

            Starvation(constOfHunger);

            if (starvation)
                TakeDamage(hungerDyingConst);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // открыть/закрыть окно с параметрами
            showStats = !showStats;

        if (alive)
        {

            if (currentHealth <= 0 && alive)
                Die();

            if (EXP > ExpToLvlUp)
                lvlUp();
        }
    }

	public void lvlUp()
    {
        lvl++;
		EXP -= ExpToLvlUp;
        this.ExpToLvlUp += Mathf.Floor(ExpToLvlUp / 2.5f); //
        lvlUpPoints += 5;
    }

    public void TakeDamage(float damage)
    {
        // придумать что-то получше
        // damage *= (100 - sanity.GetValue()) / 100; 
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        Debug.Log(transform.name + " takes " + damage + " damage.");        
    }

    public virtual void Die()
    {
        alive = false;
        // some cruel way of death
        Debug.Log(transform.name + " died.");
    }

    public void FallingAsleep(float amount)
    {
        sleepiness += amount;
		if (sleepiness >= maxValue)
        {
			sleepiness = maxValue;
            if (!sleeping)
                FallAsleep();
        }
        else
            if (sleeping) sleeping = false;
    }

    public void FallAsleep()
    {
        // some cruel way of falling asleep
        Debug.Log(transform.name + " is sleeping.");
        sleeping = true;
    }

    public void Starvation(float amount)
    {
        hunger -= amount;
		if (hunger <= 0)
        {
			hunger = 0;
            if (!starvation)
                HungerDyingState();
		}
		else
			if (starvation) starvation = false;

		if (hunger >= maxValue) {
			hunger = maxValue;
		} 
           
    }

    public void HungerDyingState()
    {
        // some cruel way of starvation
        Debug.Log(transform.name + " starvation");
        starvation = true;
    }

    public void changeMoney(float amount)
    {
        money += amount;
        if (money < 0)
            money = 0;
    }

    public void EarnEXP(int amount)
    {
        EXP += amount;
        if (EXP > ExpToLvlUp)
            lvlUp();
    }

    void OnGUI()
    {
        if (showStats) //если статы отображаются 
        {
            //Рисуем наши статы 
			GUI.Label(new Rect(1000, 30, 500, 150), "stats:");
            GUI.Label(new Rect(1200, 40, 300, 300), "LvL: " + lvl);
            GUI.Label(new Rect(1200, 25, 300, 300), "EXP: " + Mathf.FloorToInt(EXP));
            GUI.Label(new Rect(1200, 10, 300, 300), "HP: " + Mathf.FloorToInt(currentHealth));
            GUI.Label(new Rect(1350, 10, 300, 300), "Money: " + money);
            GUI.Label(new Rect(1200, 55, 300, 300), "Hunger: " + Mathf.FloorToInt(hunger));
            GUI.Label(new Rect(1200, 70, 300, 300), "Sleepiness: " + Mathf.FloorToInt(sleepiness));
            GUI.Label(new Rect(1350, 25, 300, 300), "Sanity: " + Mathf.FloorToInt(sanity));
            GUI.Label(new Rect(1350, 40, 300, 300), "Intelligence: " + intelligence);
            GUI.Label(new Rect(1350, 55, 300, 300), "Agility: " + agility);
            GUI.Label(new Rect(1350, 70, 300, 300), "Authority: " + authority);


            if (lvlUpPoints > 0) //если очков статов больше 0 делаем кнопки для повышения статов 
            {
                GUI.Label(new Rect(10, 295, 300, 20), "points " + lvlUpPoints.ToString());
                if (GUI.Button(new Rect(150, 235, 20, 20), "+")) //Для ума 
                {
                    if (lvlUpPoints > 0)
                    {
                        lvlUpPoints -= 1;
                        intelligence += 5;
                    }
                }
                if (GUI.Button(new Rect(150, 255, 20, 20), "+")) //Для проворства  
                {
                    if (lvlUpPoints > 0)
                    {
                        lvlUpPoints -= 1;
                        agility += 5;
                    }
                }
                if (GUI.Button(new Rect(150, 275, 20, 20), "+")) //Для аворитета 
                {
                    if (lvlUpPoints > 0)
                    {
                        lvlUpPoints -= 1;
                        authority += 5;
                    }
                }
            }
        }
        else if (showStats)
            useGUILayout = false; //Скрываем окно статов 
    }

    public int getLVL()
    {
        return lvl;
    }

    public bool isAlive()
    {
        return alive;
    }

    public void setAlive(bool newAlive)
    {
        alive = newAlive;
    }

    public bool isSleeping()
    {
        return sleeping;
    }

    public void setSleeping(bool newSleep)
    {
        sleeping = newSleep;
    }

    public bool isStarvation()
    {
        return starvation;
    }

    public void setStarvation(bool newHunger)
    {
        starvation = newHunger;
    }
}