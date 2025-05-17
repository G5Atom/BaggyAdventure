using UnityEngine;
using UnityEngine.EventSystems;

public class Leaves : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private Vector3 offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
}
