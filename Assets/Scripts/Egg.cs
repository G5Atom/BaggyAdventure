using UnityEngine;
using UnityEngine.SceneManagement;

public class Egg : MonoBehaviour
{
    [SerializeField]
    private int sceneBuildIndex;
    public bool eggFound;

    private void Start()
    {
        eggFound = false;
    }
    private void Update()
    {
        if (eggFound == true) 
        {
            Debug.Log("Touched again");
            SceneManager.LoadScene(0);
        }
    }
    private void OnMouseDown()
    {
        eggFound = true;
    }
}
