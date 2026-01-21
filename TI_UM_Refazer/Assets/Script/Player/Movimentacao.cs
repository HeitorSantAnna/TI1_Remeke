using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movimentacao : MonoBehaviour
{
    [SerializeField] float speed = 4;

    [SerializeField] Vector2 move, rodar;

    void Start()
    {
        
    }

    //Ajustar a movimentação de camera e trabalhar nos VFX

    void Update()
    {
        //Aqui vou tentar fazer um novo sistema de movimentação

        transform.position += (transform.forward * move.y * Time.deltaTime * speed) + (transform.right * move.x * Time.deltaTime * speed);

        //Aqui vou fazer o sistema de rotação para ajudar

        transform.Rotate(rodar.y, 0, 0);
    }

    public void Moves(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
    }

    public void Rodar(InputAction.CallbackContext value)
    {
        rodar = value.ReadValue<Vector2>();
    }
}
