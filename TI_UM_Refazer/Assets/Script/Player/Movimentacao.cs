using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movimentacao : MonoBehaviour
{
    [SerializeField] float speed = 4;

    [SerializeField] Vector2 move;

    public Slider slider;

    float energy = 10, life = 3;

    void Start()
    {
        
    }

    void Update()
    {
        //Aqui é o script para movimentar o player

        transform.position = new Vector3(transform.position.x + move.x * Time.deltaTime * speed, transform.position.y + move.y * Time.deltaTime * speed, 0);
    }

    public void Moves(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
    }
}
