using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public List<Passenger> passengers;
    public CountryItems[] countries;

    public static Queue instance;
    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            passengers = new List<Passenger>();

            for (int i = 0; i < 3; i++)
            {
                passengers.Add(new Passenger(countries[Random.Range(0, countries.Length)]));
            }
        }
        var hubUI = FindObjectOfType<HubUIScript>();
        if (hubUI != null)
        {
            hubUI.UpdatePassengerText();
        }
    }

    public static void SkipPassenger()
    {
        instance.passengers.RemoveAt(0);
        instance.passengers.Add(new Passenger(instance.countries[Random.Range(0, instance.countries.Length)]));
        var hubUI = FindObjectOfType<HubUIScript>();
        if (hubUI != null)
        {
            hubUI.UpdatePassengerText();
        }
    }

    public static CountryItems GetCurrentPassengerCountry()
    {
        return instance.passengers[0].GetPassengerCountry();
    }

    public static int GetCurrentPassengerMoney()
    {
        return instance.passengers[0].GetPassengerMoney();
    }
}