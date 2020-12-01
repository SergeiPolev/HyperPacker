using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneOnTwoItem : Item
{
    private void Awake()
    {
        RenderCountryItem();
    }
    public void RenderCountryItem()
    {
        countryItems = Queue.GetCurrentPassengerCountry();
        GetComponent<SpriteRenderer>().sprite = countryItems.oneOnTwo[Random.Range(0, countryItems.oneOnOne.Length)];
    }
}
