using UnityEngine;

public class Leaves : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    void Update()
    {
        if (dragging) 
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }    
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        dragging = true; 
    }

    private void OnMouseUp() 
    {
        dragging = false;
    }
}
