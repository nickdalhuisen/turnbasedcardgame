using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats instance;
   [SerializeField] private int MaxEnemyHealth;
   public int CurrentEnemyHealth;
    public bool enemyIsBlocking;
    [SerializeField] private Image FillHealth;
    [SerializeField] GameObject Shield;


    void Start()
    {
        if(instance == null)
        {
            instance = this;
          
        }
        else
        {
            Destroy(this);
        }
        CurrentEnemyHealth = MaxEnemyHealth;
        enemyIsBlocking = false;
    }

   
    void Update()
    {
        if (enemyIsBlocking)
        {
            Shield.SetActive(true);
        }
        else
        {
            Shield.SetActive(false);
        }
        
        if(CurrentEnemyHealth >= MaxEnemyHealth)
        {
            CurrentEnemyHealth = MaxEnemyHealth;
        }
        FillHealth.fillAmount = CurrentEnemyHealth / 10f;
    }
}
