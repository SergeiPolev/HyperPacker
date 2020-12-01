using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public float placingOffsetX = 0f;
    public float placingOffsetY = 0f;
    public LayerMask cellLayer;
    public LayerMask blockLayer;
    public bool interactable;
    public CountryItems countryItems;

    private Vector3 startingPosition;
    private bool placed;


    private void Start()
    {
        startingPosition = transform.position;
        if (!interactable)
            placed = true;

        countryItems = Queue.GetCurrentPassengerCountry();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 input = touch.position;
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(input.x + placingOffsetX, input.y + placingOffsetY, 10f));
                }
            }
            else
            {
                var input = Input.mousePosition;
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(input.x + placingOffsetX, input.y + placingOffsetY, 10f));
                placed = false;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            var cells = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().bounds.size, 0f, cellLayer);
            foreach (Collider2D cell in cells)
            {
                cell.GetComponent<Cell>().DeleteItem(this);
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            var cells = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().bounds.size, 0f, cellLayer);
            var block = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().bounds.size, 0f, blockLayer);
            bool canPlace = true;
            foreach (Collider2D cell in cells)
            {
                if ((cell.GetComponent<Cell>().IsEmpty(this) != true) || block.Length != 0)
                {
                    canPlace = false;
                }
            }

            if (!placed || !canPlace)
            {
                SetStartingPosition();
            }
            else
            {
                foreach (Collider2D cell in cells)
                {
                    cell.GetComponent<Cell>().AddItem(this);
                }
            }
        }
    }

    public void SetStartingPosition()
    {
        transform.position = startingPosition;
    }
    public bool GetPlaced()
    {
        return placed;
    }
    public void SetPlaced()
    {
        placed = true;
    }
    public void ResetPlaced()
    {
        placed = false;
    }
    public bool IsInteractable()
    {
        return interactable;
    }
}
