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

    public Image characterArt, bgArt;
    

    // Start is called before the first frame update
    void Start()
    {
        SetupCard();


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
        bgArt.sprite = CardSO.bgSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
