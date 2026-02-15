using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movimentacao : MonoBehaviour
{
    [SerializeField] float speed = 4;

    [SerializeField] Vector2 move, rodar;

    [SerializeField] Camera cam;

    public PlayerInfo playerData;

    void Start()
    {
        
    }

    //Ajustar a movimentação (talvez colocar a camera filha do player????) de camera e trabalhar nos VFX
    //Colocar para que quando a camera se movimentar o player rotacionar

    void Update()
    {
        //Aqui vou tentar fazer um novo sistema de movimentação
        transform.position += (cam.transform.forward * move.y * Time.deltaTime * speed) + (transform.right * move.x * Time.deltaTime * speed);

        //Aqui vou fazer o sistema de rotação para ajudar
        transform.Rotate(rodar.y, rodar.x, 0);
    }

    public void Moves(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
    }

    public void Rodar(InputAction.CallbackContext value)
    {
        rodar = value.ReadValue<Vector2>();
    }

    public void Sincronize()
    {
        playerData = new PlayerInfo();

        playerData.position = transform.position;
    }

    public void Load(PlayerInfo data)
    {
        playerData = new PlayerInfo();

        playerData = data;

        transform.position = playerData.position;
    }
}
