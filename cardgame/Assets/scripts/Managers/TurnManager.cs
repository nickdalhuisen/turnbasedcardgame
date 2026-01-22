using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public enum CurrentPlayer
    {
        enemy,
        Player
    }
   public CurrentPlayer currentPlayer;
    // scripts
   [SerializeField] EnemyAi enemyAi;
    [SerializeField] TMP_Text turn;
    

    void Start()
    {
        if (instance == null)
        {
            instance = this;
           
        }
        else
        {
            Destroy(this);
        }
        currentPlayer = CurrentPlayer.Player;
    }

   
    void Update()
    {
        StateMaschine();
        turn.text = "turn:" + currentPlayer;
    }
    public void StateMaschine()
    {
        switch (currentPlayer)
        {
            case CurrentPlayer.Player:
                break;
            case CurrentPlayer.enemy:
                enemyAi.ChooseCard();
                break;
        }
        
    }

}
