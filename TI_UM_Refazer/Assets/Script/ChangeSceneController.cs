using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    public void InGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
