using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameController game;

    void Start()
    {
        game = GetComponent<GameController>();

        DontDestroyOnLoad(game);

        Debug.Log("Olá Mundo!!!");
    }

    void Update()
    {
        
    }

    public void InGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
