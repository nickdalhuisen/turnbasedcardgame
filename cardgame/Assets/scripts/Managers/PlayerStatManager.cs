using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    public int CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

   
    void Update()
    {
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
}
