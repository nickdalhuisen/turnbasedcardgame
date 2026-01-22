using UnityEngine;
using UnityEngine.SceneManagement;
public class SwithScenes : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
       if(PlayerStatManager.instance.CurrentHealth <= 0)
        {
            LoseScene();
        }
       if(EnemyStats.instance.CurrentEnemyHealth <= 0)
        {
            WinScreen();
        }
        
    }
    public void StartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }
    public void WinScreen()
    {
        SceneManager.LoadScene("WinScene");
    }
    public void LoseScene()
    {
        SceneManager.LoadScene("DeadScene");
    }
    public void MainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void LeaveGame()
    {

Application.Quit();
    }
}
