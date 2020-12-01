using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGrid : MonoBehaviour
{
    private SpriteRenderer grid;

    private void Start()
    {
        grid = GetComponent<SpriteRenderer>();
    }

    public void HideAllGrids()
    {
        grid.color = new Color(1, 1, 1, 0);
    }
}
