using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIElementsPlacer : MonoBehaviour
{
    private Bag currentBag;
    public Button finishButton;
    public TextMeshProUGUI levelNumber;

    private void Awake()
    {
        currentBag = FindObjectOfType<Bag>();
        levelNumber.text = "Level " + PlayerPrefs.GetInt("Current Level");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            finishButton.gameObject.SetActive(currentBag.CanFinish());
        }
    }
    public void FinishLevel()
    {
        currentBag.FinishGame();
        finishButton.GetComponent<Button>().interactable = false;
    }
}