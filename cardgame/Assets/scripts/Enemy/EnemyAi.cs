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

    }
    public void ChooseCard()
    {
        if(ThinkTimer <= 4 )
        {
            ThinkTimer += Time.deltaTime;
            Debug.Log("Enemy is thinking of a card");
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
                Debug.Log("enemy did damage");
                StatManager.CurrentHealth -= 20;
            }
            else if (Chance > NumberOne && Chance <= NumberTwo)
            {
                Debug.Log("enemy chose to heal");
                enemyStats.CurrentEnemyHealth += 20;
            }
            else if (Chance > NumberTwo && Chance <= 100)
            {
                Debug.Log("enemy chose to block your next shot");
                enemyStats.enemyIsBlocking = true;
            }

            Chance = 0;
            ChoseNumber = false;
            GeneratedNumber = false;
            TurnManager.instance.currentPlayer = TurnManager.CurrentPlayer.Player;
        }
    }
        


    }

