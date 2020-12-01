using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public List<Item> items;
    public LayerMask itemsLayer;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && IsEmpty() && eventData.pointerDrag.GetComponent<Item>().IsInteractable())
        {
            var item = eventData.pointerDrag.GetComponent<Item>();
            item.SetPlaced();
            eventData.pointerDrag.transform.position = transform.position + new Vector3(item.placingOffsetX, item.placingOffsetY);
            eventData.pointerDrag.transform.SetParent(transform);
        }
    }

    public void FinishLevel()
    {
        Collider2D[] itemsOverlap = Physics2D.OverlapCircleAll(transform.position, 0.2f, itemsLayer);
        if (itemsOverlap.Length > 1)
        {
            FindObjectOfType<Bag>().SetFailed();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!IsEmpty())
        {
            var item = items[0].gameObject.GetComponent<Item>();
            DeleteItem(item);
            item.transform.SetParent(null);
            item.ResetPlaced();
        }
    }
    private void OnMouseDown()
    {
        if (!IsEmpty())
        {
            var item = items[0].gameObject.GetComponent<Item>();
            item.transform.SetParent(null);
            item.ResetPlaced();
            DeleteItem(item);
        }
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        spriteRenderer.color =  new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.6f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public bool IsEmpty(Item item)
    {
        return (items.Count == 1 && items.Contains(item)) || items.Count == 0;
    }

    public void SetItem(Item item)
    {
        items.Add(item);
    }

    public void DeleteItem(Item item)
    {
        items.Remove(item);
    }
}
