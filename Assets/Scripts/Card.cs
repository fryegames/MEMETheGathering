using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardScriptableObject CardSO;

    public int currentHealth;
    public int attackPower, manaCost;

    public TMP_Text healthText, attackText, costText, nameText, actionDescriptionText, loreText;

    public Image characterArt;

    private Vector3 targetPoint;
    private Quaternion targetRot;
    public float moveSpeed = 5f, rotateSpeed = 540f;

    public bool inHand;
    public int handPosition;

    private HandController theHC;

    
    // Start is called before the first frame update
    void Start()
    {
        SetupCard();
        theHC = FindObjectOfType<HandController>();
    }

    public void SetupCard()
    {
        currentHealth = CardSO.currentHealth;
        attackPower = CardSO.attackPower;
        manaCost = CardSO.manaCost;

        healthText.text = currentHealth.ToString();
        attackText.text = attackPower.ToString();
        costText.text = manaCost.ToString();

        nameText.text = CardSO.cardName;
        actionDescriptionText.text = CardSO.actionDescription;
        loreText.text = CardSO.cardLore;

        characterArt.sprite = CardSO.characterSprite;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);  
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
    }

    public void MoveToPoint(Vector3 pointToMoveTo, Quaternion rotToMatch)
    {
        targetPoint = pointToMoveTo;
        targetRot = rotToMatch;
    }

    private void OnMouseOver()
    {
        if(inHand)
        {
            MoveToPoint(theHC.cardPositions[handPosition] + new Vector3(0f, 1f, .5f), Quaternion.identity);
        }
    }

    private void OnMouseExit()
    {
        if(inHand)
        {
            MoveToPoint(theHC.cardPositions[handPosition], theHC.minPos.rotation);
        }
    }
}
