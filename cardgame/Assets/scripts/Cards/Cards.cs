using UnityEngine;

public class Cards : MonoBehaviour
{
    public float WhatCardDoes;
    public int Number;
    public int ManaCost;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Destroy()
    {
    
      HandManager.instance.RemoveCard(gameObject);

        Destroy(gameObject);
        
    }
}
