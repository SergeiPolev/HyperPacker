using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoOnOneItem : Item
{
    private void Awake()
    {
        RenderCountryItem();
    }
    public void RenderCountryItem()
    {
        countryItems = Queue.GetCurrentPassengerCountry();
        GetComponent<SpriteRenderer>().sprite = countryItems.twoOnOne[Random.Range(0, countryItems.twoOnOne.Length)];
    }
}
