using UnityEngine;
using UnityEngine.InputSystem;

public class CanvaControllers : MonoBehaviour
{
    [SerializeField] bool pauseMenu = false;

    [SerializeField] int pause = 0;

    [SerializeField] GameObject Pause;

    void Start()
    {
        
    }

    void Update()
    {
        if(pauseMenu && pause == 1)
        {
            Pause.SetActive(true);
        }
        else if(pauseMenu && pause == 0)
        {
            Pause.SetActive(false);
        }
    }

    public void Pauses(InputAction.CallbackContext value)
    {
        if(!value.performed)
        {
            return;
        }

        pauseMenu = value.ReadValueAsButton();

        if(pause == 0)
        {
            pause = 1;
        }
        else
        {
            pause = 0;
        }
    }
}
