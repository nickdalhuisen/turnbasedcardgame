using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private int Chance;
    private bool GeneratedNumber;
    public float ThinkTimer;
    bool ChoseNumber;
   [SerializeField] PlayerStatManager StatManager;
    [SerializeField] int NumberOne;
    [SerializeField] int NumberTwo;
   
    EnemyStats enemyStats;
    [SerializeField] GameObject healparticle;
    bool healed;
    float HealParticleTime;
    void Start()
    {
        GeneratedNumber = false;
        enemyStats = GetComponent<EnemyStats>();
        ChoseNumber = false;
        NumberOne = 33;
        NumberTwo = 66;
    }

    
    void Update()
    {
        if(healed == true)
        {
            HealParticleTime += Time.deltaTime;
            healparticle.SetActive(true);
        }
        if(HealParticleTime >= 1.5f)
        {
            healparticle.SetActive(false);
            HealParticleTime = 0;
            healed = false;
        }
        
    }
    public void ChooseCard()
    {
        if(ThinkTimer <= 4 )
        {
            ThinkTimer += Time.deltaTime;
            
        }
        else if(ThinkTimer >= 4)
        {
            if (GeneratedNumber == false)
            {
                Chance = Random.Range(1, 100);
                GeneratedNumber = true;
                ChoseNumber = true;
                ThinkTimer = 0;
            }
        }

        if(ChoseNumber == true) 
        {
            if (Chance >1 && Chance <= NumberOne)
            {
                AudioManager.instance.Play("hoyaaa");
                Debug.Log("enemy did damage");
                if(StatManager.IsBlocking == false)
                {
                    StatManager.CurrentHealth -= 2;
                }

                StatManager.IsBlocking = false;
            }
            else if (Chance > NumberOne && Chance <= NumberTwo)
            {
                AudioManager.instance.Play("heal");
                enemyStats.CurrentEnemyHealth += 1;
                StatManager.IsBlocking = false;
                healed = true;
            }
            else if (Chance > NumberTwo && Chance <= 100)
            {
                AudioManager.instance.Play("bonk");
                enemyStats.enemyIsBlocking = true;
            }

            Chance = 0;
            ChoseNumber = false;
            GeneratedNumber = false;
            TurnManager.instance.currentPlayer = TurnManager.CurrentPlayer.Player;
        }
    }
        


    }

