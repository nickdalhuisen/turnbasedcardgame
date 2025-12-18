using UnityEngine;

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
    

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
