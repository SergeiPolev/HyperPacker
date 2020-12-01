using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DollarCounter : MonoBehaviour
{
    private TextMeshProUGUI dollarText;

    private void Awake()
    {
        dollarText = GetComponentInChildren<TextMeshProUGUI>();
        dollarText.text = PlayerPrefs.GetInt("Current Balance", 0).ToString();
    }
}
