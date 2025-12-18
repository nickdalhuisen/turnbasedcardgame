using UnityEngine;

public class OnClicks : MonoBehaviour
{
    [SerializeField] EnemyAi enemyAi;
    [SerializeField] EnemyStats enemystats;
    public void OnClick()
    {
        if (TurnManager.instance.currentPlayer == TurnManager.CurrentPlayer.Player)
        {
            if (TurnManager.instance.currentPlayer == TurnManager.CurrentPlayer.Player)
            {
                TurnManager.instance.currentPlayer = TurnManager.CurrentPlayer.enemy;
            }
            enemyAi.ThinkTimer = 0;
        }
           
        
        

    }
    public void DoDamage()
    {
        if (TurnManager.instance.currentPlayer == TurnManager.CurrentPlayer.Player)
        {
            if (enemystats.enemyIsBlocking == false)
            {
                enemystats.CurrentEnemyHealth -= 20;

            }
            else
            {
                enemystats.enemyIsBlocking = false;
            }
        }


    }
}
    