using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

using UnityEngine;
using UnityEngine.Splines;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;


    [SerializeField] private int MaxHandSize;
     GameObject CurrentcardPrefab;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform CardSpawn;
    [SerializeField] List<GameObject> allCards = new();
    public List<GameObject> handCards = new();
    public float SpawnCard;
    private int randomnumber;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
           
        }
        else
        {
            Destroy(this);
        }
    }
        
        
    private void Update()
    {
        SpawnCard += Time.deltaTime;
        if (SpawnCard >= 1)
        {
            DrawCard();
            SpawnCard = 0;
        }
       if(handCards == null)
        {
            
        }
    }
    private void DrawCard()
    {
        if (handCards.Count >= MaxHandSize) return;
        randomnumber = Random.Range(0, allCards.Count);
        if(randomnumber == 0)
        {
           CurrentcardPrefab = allCards[0];
        }
        else if (randomnumber == 1)
        {
            CurrentcardPrefab = allCards[1];
        }
        else if (randomnumber == 2)
        {
            CurrentcardPrefab = allCards[2];
        }
        else if (randomnumber == 3)
        {
            CurrentcardPrefab = allCards[3];
        }
        else if (randomnumber == 4)
        {
            CurrentcardPrefab = allCards[4];
        }
        else if (randomnumber == 5)
        {
            CurrentcardPrefab = allCards[5];
        }

        GameObject g = Instantiate(CurrentcardPrefab, CardSpawn.position, CardSpawn.rotation);
        handCards.Add(g);
        UpdatePosition();
    }
    private void UpdatePosition()
    { if (handCards.Count == 0) return;
        float cardSpacing = 1f / MaxHandSize;
        float FirstCardPosition = 0.5f - (handCards.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;
        for (int i = 0; i < handCards.Count; i++)
        {
            float p = FirstCardPosition + i * cardSpacing;
            Vector3 SplinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateTangent(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            handCards[i].transform.DOMove(SplinePosition, 0.7f);
           
        }
    }
    public void RemoveCard(GameObject card)
    {
        if (handCards.Contains(card))
        {
            handCards.Remove(card);
            Destroy(card);
            UpdatePosition();
        }
    }
}
