using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Egg : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private int sceneBuildIndex;
    [SerializeField]
    private GameObject miniGame;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject leafPile;
    [SerializeField]
    private PlayerControllerInput playerControllerInput;


    public void OnPointerDown(PointerEventData eventData)
    {
        playerControllerInput. levelLoader = null;
        player.SetActive(true);
        leafPile.SetActive(false);
        miniGame.SetActive(false);

    }
}
