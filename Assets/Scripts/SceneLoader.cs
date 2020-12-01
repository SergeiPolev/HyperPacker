using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadHub()
    {
        var bag = FindObjectOfType<Bag>();

        if (bag != null)
        {
            bool failed = bag.GetFailed();
            int currentLevel = PlayerPrefs.GetInt("Current Level", 1);
            if (SceneManager.sceneCountInBuildSettings - 1 == currentLevel)
            {
                PlayerPrefs.SetInt("Current Level", (failed) ? currentLevel : 1);
            }
            else
            {
                PlayerPrefs.SetInt("Current Level", (failed) ? currentLevel : currentLevel + 1);
            }
        }

        SceneManager.LoadScene("Hub");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("Current Level", 1).ToString());
    }
}
