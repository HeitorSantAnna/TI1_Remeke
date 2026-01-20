using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
