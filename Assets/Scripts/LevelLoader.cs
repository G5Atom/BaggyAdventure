using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public bool enteredLeafPile;
    private PlayerControllerInput controller;

    private void Start()
    {
        controller = FindAnyObjectByType<PlayerControllerInput>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if(other.tag == "Player")
        {
            controller.levelLoader = this;
          enteredLeafPile = true;            
        }
    }


}
