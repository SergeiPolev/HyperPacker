using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HubUIScript : MonoBehaviour
{
    public TextMeshProUGUI dollarText;
    public TextMeshProUGUI countryText;

    public void UpdatePassengerText()
    {
        dollarText.text = Queue.GetCurrentPassengerMoney().ToString();
        countryText.text = Queue.GetCurrentPassengerCountry().countryName;
    }
}
