using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharDisplay : MonoBehaviour
{
    public int PlayerNum;
    public CharacterCard character1;
    public CharacterCard character2;
    public CharacterCard character3;
    public CharacterCard character4;
    public CharacterCard character5;

    public int characterNum;

    public bool selected = false;
    bool isAxisInUse = false;


    public class PlayerCard
    {
        public CharacterCard current;
        public CharacterCard next;
        public CharacterCard previous;

        public PlayerCard(CharacterCard Current)
        {
            current = Current;
        }

        public PlayerCard(CharacterCard Current, CharacterCard Forward, CharacterCard Previous)
        {
            current = Current;
            next = Forward;
            previous = Previous;
        }

    }

    public PlayerCard card;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerNum == 1)
        {
            gameObject.GetComponent<Image>().sprite = character1.art;
            card = new PlayerCard(character1);
            UpdatePlayerCard();
        }
        else if (PlayerNum == 2)
        {
            gameObject.GetComponent<Image>().sprite = character1.art;
            card = new PlayerCard(character1);
            UpdatePlayerCard();
        }
        else if (PlayerNum == 3)
        {
            gameObject.GetComponent<Image>().sprite = character1.art;
            card = new PlayerCard(character1);
            UpdatePlayerCard();
        }
        else if (PlayerNum == 4)
        {
            gameObject.GetComponent<Image>().sprite = character1.art;
            card = new PlayerCard(character1);
            UpdatePlayerCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCharacter();
    }

    void ChangeCharacter()
    {
        if (!selected)
        {

            if (Input.GetAxis("DPadX_P" + PlayerNum) > 0)
            {
                if (isAxisInUse == false)
                {
                    gameObject.GetComponent<Image>().sprite = card.next.art;
                    card.current = card.next;
                    UpdatePlayerCard();
                    isAxisInUse = true;
                }
            }
            else if (Input.GetAxis("DPadX_P" + PlayerNum) < 0)
            {
                if (isAxisInUse == false)
                {
                    gameObject.GetComponent<Image>().sprite = card.previous.art;
                    card.current = card.previous;
                    UpdatePlayerCard();
                    isAxisInUse = true;
                }
            }

            if (Input.GetAxis("DPadX_P" + PlayerNum) == 0)
            {
                isAxisInUse = false;
            }
            if (Input.GetButtonDown("A_P" + PlayerNum))
            {
                selected = true;
                //highlight border here
            }

        }
        else if (selected)
        {
            if (Input.GetButtonDown("B_P" + PlayerNum))
            {
                selected = false;
                //unhighlight border here
            }
        }


    }


    void UpdatePlayerCard()
    {
        if (card.current == character1)
        {
            characterNum = 1;
            card.next = character2;
            card.previous = character5;
        }
        else if (card.current == character2)
        {
            characterNum = 2;
            card.next = character3;
            card.previous = character1;
        }
        else if (card.current == character3)
        {
            characterNum = 3;
            card.next = character4;
            card.previous = character2;
        }
        else if (card.current == character4)
        {
            characterNum = 4;
            card.next = character5;
            card.previous = character3;
        }
        else if(card.current == character5)
        {
            characterNum = 5;
            card.next = character1;
            card.previous = character4;
            
        }

    }




}


