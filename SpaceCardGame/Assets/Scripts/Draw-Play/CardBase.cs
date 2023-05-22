using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBase : MonoBehaviour
{
    public Text cardName;
    public Text manaCost;
    public BaseCard so;
    public bool isInHand;

    // Start is called before the first frame update
    void Start()
    {
        cardName.text = so.cardName;
        manaCost.text = so.manaCost.ToString();
    }
}
