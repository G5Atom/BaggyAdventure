using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    [SerializeField]
    private PlayerControllerInput controller;
    public TMP_Text counterText;

    private void Start()
    {
        controller = FindAnyObjectByType<PlayerControllerInput>();
    }


    private void Update()
    {
        DestroyObject();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            controller.interactable = this;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            isInRange = false;
            controller.interactable = null;
        }

        if (collision.CompareTag("Egg") && collision.gameObject.activeSelf) 
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void DestroyObject()
    {
        if ( controller.canDestroy)
        {            
            StartCoroutine(DestroyRoutine());
        }
    }

    IEnumerator DestroyRoutine()
    {
        if(isInRange)
        {
        yield return new WaitForSeconds(0.1f);
        controller.canDestroy = false;
        controller.interactable = null;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
        }
    }

}
