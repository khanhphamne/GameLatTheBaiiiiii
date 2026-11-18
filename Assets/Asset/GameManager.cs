using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform cardContainer;
    public GameObject cardPrefabs;
    public Sprite[] cardIcons;
    public int count = 0;
    private int id1, id2;
    void Start()
    {
        for (int i = 0; i < cardIcons.Length; i++)
        {
            GameObject card1 = Instantiate(cardPrefabs, cardContainer);
            GameObject card2 = Instantiate(cardPrefabs, cardContainer);
            card1.GetComponent<CardController>().InitCard(i, cardIcons[i]);
            card2.GetComponent<CardController>().InitCard(i, cardIcons[i]);
        }
        for (int i = 0; i < 30; i++)
        {
            int rand = Random.Range(0, cardContainer.childCount);
            cardContainer.GetChild(rand).SetAsFirstSibling();
        }
    }
    public void CheckCard(int id)
    {
        if(count == 0)
        {
            id1 = id;
            count++;
        }
        else if(count == 1)
        {
            id2 = id;
            count++;
            StartCoroutine(WaitForSeconds(id));
        }
    }
    IEnumerator WaitForSeconds(int id)
    {
        yield return new WaitForSeconds(2f);
        if(id1 == id2)
        {
            destroy(id);
        }
        else
        {
            reset(id1, id2);
        }
        count = 0;
    }
    private void destroy(int id)
    {
        for(int i = 0; i < cardContainer.childCount; i++)
        {
            if(cardContainer.GetChild(i).GetComponent<CardController>().id == id)
            {
                cardContainer.GetChild(i).GetComponent<CanvasGroup>().alpha = 0;
                cardContainer.GetChild(i).GetComponent<CanvasGroup>().blocksRaycasts = false;
                cardContainer.GetChild(i).GetComponent<CanvasGroup>().interactable = false;
            }
        }
    }
    private void reset(int id1, int id2)
    {
        for(int i = 0; i < cardContainer.childCount; i++)
        {
            if(cardContainer.GetChild(i).GetComponent<CardController>().id == id1 || cardContainer.GetChild(i).GetComponent<CardController>().id == id2)
            {
                if(cardContainer.GetChild(i).GetComponent<Animator>().GetBool("isFlip") == true)
                {
                    cardContainer.GetChild(i).GetComponent<Animator>().SetBool("isFlip", false);
                }
            }
        }
    }
}
