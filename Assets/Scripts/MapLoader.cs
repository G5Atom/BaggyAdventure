using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour
{
    public int sceneBuildIndex;
    [SerializeField]
    private PlayerControllerInput player;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerControllerInput>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player" && player.eggCounter >= 3)
             
        {
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
