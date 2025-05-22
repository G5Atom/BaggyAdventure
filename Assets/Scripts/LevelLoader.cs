using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public bool enteredLeafPile;
    private PlayerControllerInput controller;
    [SerializeField]
    private GameObject miniGame;

    private void Start()
    {
        controller = FindAnyObjectByType<PlayerControllerInput>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if(other.tag == "Player")
        {
            controller.leafMiniGame = miniGame;
            controller.levelLoader = this;
          enteredLeafPile = true;            
        }
    }


}
