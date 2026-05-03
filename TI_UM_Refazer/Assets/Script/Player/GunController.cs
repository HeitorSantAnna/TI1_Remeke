using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    private bool fire = false;

    [SerializeField] GameObject bulletImage;

    private Image image;

    void Start()
    {
        image = bulletImage.GetComponent<Image>();
        image.fillAmount = 1f;
    }

    void Update()
    {
        
    }

    public void Fire(InputAction.CallbackContext value)
    {
        fire = value.ReadValue<bool>();
    }
}
