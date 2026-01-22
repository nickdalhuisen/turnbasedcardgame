
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class HoverOver : MonoBehaviour
{
    private Transform CurrentCardHover;
    private Vector3 NormalCardSize;
    private Vector3 BiggerCardSize;
    private Vector3 CardPosHover;
    private Vector3 NormalCardPos;
    private bool IsOnCard;
    private Cards cards;
    public InputSystem_Actions newactions;
    
    [SerializeField] PlayerStatManager playerStatManager;
    [SerializeField] bool clicked;
  
  
    
    public void Start()
    {
        IsOnCard = false;
        NormalCardSize = new Vector3 (0.03f, 0.03f, 0.03f);
        BiggerCardSize = new Vector3(0.05f,0.05f, 0.05f);

        newactions = new InputSystem_Actions();
        newactions.Player.Enable();
        newactions.Player.Attack.performed += OnClick;
        clicked = false;
    }
    private void Update()
    {
        if (Mouse.current == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());



        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100) && hit.transform.CompareTag("Card"))
        {
            Debug.Log("Hit ");
            CurrentCardHover = hit.transform;
            CurrentCardHover.localScale = BiggerCardSize;
            IsOnCard=true;
            playerStatManager.IsBlocking = false;
            cards = hit.transform.gameObject.GetComponent<Cards>();
            if(clicked)
            {
                clicked = false;
                if (cards.Number == 2f)
                {
                    DoAttack();
                  
                }
                else if (cards.Number == 1f)
                {
                    Heal();
                   
                }
                else if (cards.Number == 3f)
                {
                    Block();
                  
                }
                else if(cards.Number == 4)
                {
                    GiveMana();
                }

            }

           
        }
        else
        {
          CurrentCardHover.localScale = NormalCardSize;
            IsOnCard=false;
        }
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (IsOnCard && TurnManager.instance.currentPlayer == TurnManager.CurrentPlayer.Player)
        {
            Debug.Log("Card Clicked");
            clicked = true;
            TurnManager.instance.currentPlayer = TurnManager.CurrentPlayer.enemy;
            
        }
    }
    private void DoAttack()
    {
        if (PlayerStatManager.instance.Mana >= cards.ManaCost)
        {
            AudioManager.instance.Play("hoyaaa");
            if (EnemyStats.instance.enemyIsBlocking == false)
            {
                
                EnemyStats.instance.CurrentEnemyHealth -= cards.Number;
                PlayerStatManager.instance.Mana -= cards.ManaCost;
            }
        }

        cards.Destroy();
    }
        
      
    
    private void Block()
    {
        if(PlayerStatManager.instance.Mana >= cards.ManaCost)
        {
            playerStatManager.IsBlocking = true;
          
            EnemyStats.instance.enemyIsBlocking = false;
            PlayerStatManager.instance.Mana -= cards.ManaCost;
        }
        cards.Destroy();
    }
    private void Heal()
    {
        if (PlayerStatManager.instance.Mana >= cards.ManaCost)
        {
            AudioManager.instance.Play("heal");
            playerStatManager.CurrentHealth += cards.Number;

            EnemyStats.instance.enemyIsBlocking = false;
            PlayerStatManager.instance.Mana -= cards.ManaCost;
        }
        cards.Destroy();
    }
    private void GiveMana()
    {
        AudioManager.instance.Play("evil");
        EnemyStats.instance.enemyIsBlocking = false;
        PlayerStatManager.instance.Mana += cards.WhatCardDoes;
        cards.Destroy();
    }
}
