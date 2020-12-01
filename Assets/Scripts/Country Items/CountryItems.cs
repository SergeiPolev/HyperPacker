using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Country Items", menuName ="Countries", order = 1)]
public class CountryItems : ScriptableObject
{
    public string countryName;
    public Sprite[] oneOnOne;
    public Sprite[] twoOnOne;
    public Sprite[] oneOnTwo;
}
