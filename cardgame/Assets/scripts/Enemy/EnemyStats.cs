using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
   [SerializeField] private int MaxEnemyHealth;
   public int CurrentEnemyHealth;
    public bool enemyIsBlocking;
    [SerializeField] private Image FillHealth;
    void Start()
    {
        CurrentEnemyHealth = MaxEnemyHealth;
        enemyIsBlocking = false;
    }

   
    void Update()
    {
        
        if(CurrentEnemyHealth >= MaxEnemyHealth)
        {
            CurrentEnemyHealth = MaxEnemyHealth;
        }
        FillHealth.fillAmount = CurrentEnemyHealth / 100f;
    }
}
