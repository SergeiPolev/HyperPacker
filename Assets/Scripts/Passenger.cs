using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger
{
    CountryItems passengerCountry;
    int money;

    public Passenger(CountryItems country)
    {
        passengerCountry = country;
        money = Random.Range(0, 50);
    }

    public CountryItems GetPassengerCountry()
    {
        return passengerCountry;
    }
    public int GetPassengerMoney()
    {
        return money;
    }
}
