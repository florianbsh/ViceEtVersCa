using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public UnityEvent CardStartMovingEvent = new UnityEvent();

    [SerializeField]
    private GameObject card;

    private CardMovement cardMovement;

    [SerializeField]
    private CardPosition cardPosition;

    private bool isCardSetActive = false;

    private CharacterStat characterStat = null;

    [SerializeField]
    private Text characterName;

    [SerializeField]
    private Text characterDate;

    [SerializeField]
    private Text characterFact;

    [SerializeField]
    private Image characterPrifilePicture;

    private void Awake()
    {
        this.cardMovement = this.card.GetComponent<CardMovement>();
    }

    private void Start()
    {

    }

    public void ToggleCard()
    {
        this.isCardSetActive = !this.isCardSetActive;
        this.card.SetActive(this.isCardSetActive);
    }

    public void IntroduceNewCard(CharacterStat characterStat)
    {
        this.characterStat = characterStat;

        SetCharacterStatOnCard();

        DeselectCard();
    }

    #region Card Movement
    public void SelectCard()
    {
        this.CardStartMovingEvent.Invoke();
        this.cardMovement.OnCardMoveTo(this.cardPosition.SelectedPosition, this.cardPosition.ToSelectedPositionSpeed);
    }

    public void DeselectCard()
    {
        this.CardStartMovingEvent.Invoke();
        this.cardMovement.OnCardMoveTo(this.cardPosition.DeselectedPosition, this.cardPosition.ToDeselectedPositionSpeed);
    }

    public void HideCard()
    {
        this.CardStartMovingEvent.Invoke();
        this.cardMovement.OnCardMoveTo(this.cardPosition.HidePosition, this.cardPosition.ToHidePositionSpeed);
    }
    #endregion

    private void SetCharacterStatOnCard()
    {
        this.characterName.text = this.characterStat.LastName + " " + this.characterStat.FirstName;

        this.characterDate.text = this.characterStat.YearOfBirth + " - " + this.characterStat.YearOfDeath;

        this.characterPrifilePicture.sprite = this.characterStat.ProfilePicture;

        this.characterFact.text = "";

        for (int i = 0; i < this.characterStat.Facts.Length; ++i)
        {
            this.characterFact.text += this.characterStat.Facts[i] + "\n";
        }
    }
}
