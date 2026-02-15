using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchController : MonoBehaviour
{
    [SerializeField] GameObject OnOff;

    private void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if(device is Joystick)
        {
            switch(change)
            {
                case InputDeviceChange.Added:
                case InputDeviceChange.Reconnected:
                    OnOff.SetActive(true);
                    Debug.Log("Controller conectado (New Input System)");
                    break;

                case InputDeviceChange.Disconnected:
                case InputDeviceChange.Removed:
                    OnOff.SetActive(false);
                    Debug.Log("Controller desconectado (New Input System)");
                    break;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
