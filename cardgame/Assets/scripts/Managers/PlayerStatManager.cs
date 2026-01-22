using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStatManager : MonoBehaviour
{
    public static PlayerStatManager instance;
    [SerializeField] private int MaxHealth;
    public int CurrentHealth;
    [SerializeField] private Image Filler;
    public bool IsBlocking;
    [SerializeField] public float Mana;
    [SerializeField] TMP_Text Manatext;
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
        CurrentHealth = MaxHealth;
        Mana = 15;
    }

   
    void Update()
    {
        if(Mana > 15)
        {
            Mana = 15;
        }
        if(Mana < 0)
        {
            Mana = 0;
        }
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        Filler.fillAmount = CurrentHealth / 10f;
        Manatext.text = "Mana " + Mana;
    }
}
