using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneOnOneItem : Item
{
    private void Awake()
    {
        RenderCountryItem();
    }
    public void RenderCountryItem()
    {
        countryItems = Queue.GetCurrentPassengerCountry();
        GetComponent<SpriteRenderer>().sprite = countryItems.oneOnOne[Random.Range(0, countryItems.oneOnOne.Length)];
    }
}
