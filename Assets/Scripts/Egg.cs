using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Egg : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private int sceneBuildIndex;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Touched again");
        SceneManager.LoadScene(0);
    }
}
