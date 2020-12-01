using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public GameObject[] bottomSegments;
    public GameObject[] leftSegments;
    public Transform topOfBottomSegments;
    public Transform rightOfLeftSegments;
    public float speed = 180f;
    public GameObject failSign;
    public GameObject successSign;

    private float counter = 0f;
    private bool finished = false;
    private bool failed = false;

    public bool CanFinish()
    {
        Item[] items = FindObjectsOfType<Item>();
        foreach (Item item in items)
        {
            if (!item.GetPlaced())
            {
                return false;
            }
        }
        return true;
    }
    public void FinishGame()
    {
        if (!finished)
        {
            HideGrid[] hideGrids = GetComponentsInChildren<HideGrid>();
            foreach (HideGrid hideGrid in hideGrids)
            {
                hideGrid.HideAllGrids();
            }
            StartCoroutine(Finish());
        }
        finished = true;
    }
    
    IEnumerator Finish()
    {
        while (counter < 180f)
        {
            foreach (GameObject bagSegment in bottomSegments)
            {
                bagSegment.transform.RotateAround(topOfBottomSegments.position, new Vector3(1, 0, 0), speed * Time.deltaTime);
            }
            counter += speed * Time.deltaTime;
            yield return null;
        }
        counter = 0;
        yield return new WaitForSeconds(.1f);

        while (counter < 180f)
        {
            foreach (GameObject bagSegment in leftSegments)
            {
                bagSegment.transform.RotateAround(rightOfLeftSegments.position, new Vector3(0, -1, 0), speed * Time.deltaTime);
            }
            counter += speed * Time.deltaTime;
            yield return null;
        }

        Cell[] cells = GetComponentsInChildren<Cell>();
        foreach (Cell cell in cells)
        {
            cell.FinishLevel();
        }

        if (failed)
        {
            failSign.SetActive(true);
        }
        else
        {
            successSign.SetActive(true);
            PlayerPrefs.SetInt("Current Balance", PlayerPrefs.GetInt("Current Balance", 0) + Queue.GetCurrentPassengerMoney());
            Queue.SkipPassenger();
        }

        yield return new WaitForSeconds(1f);

        FindObjectOfType<SceneLoader>().LoadHub();
    }

    public void SetFailed()
    {
        failed = true;
    }
    public bool GetFailed()
    {
        return failed;
    }
}
