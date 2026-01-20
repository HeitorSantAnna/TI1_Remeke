using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    [SerializeField] GameObject[] Bullets = new GameObject[4];
    [SerializeField] int indiceBullet = 0;
    [SerializeField] float timer = 0;

    [SerializeField] bool disparo, One, Two, Tree, Four;

    [SerializeField] float Left, Right;

    //Aqui vou colocar uma referencia da imagem, o tiro normal ia já ficar disponivel e o resto (quando ficarem disponiveis) iniciaram carregando com uma imagem preto e branco e começa a carregar quando carregar vai dar uma piscada e um som que indica que está disponivel

    [SerializeField] Image Normalrocket;

    //Rocket Thunder
    //Ele causara um curto que cancelara todas as habilidades e também travará as naves

    //Rocket Venom
    //Ele causa um dano curto ao longo do tempo e também desacelera a vave afetada

    //Rocket Fire
    //Ele causa dano de queimadura em area, se uma nave morreria ao entrar em contato com esse foguete/com o efeito de queimadura ele explode de novo e espalha fogo (agora como tem fogo no espaço onde não tem oxigenio já é outra história kkkkkkk

    void Start()
    {
        Normalrocket.fillAmount = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            indiceBullet = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            indiceBullet = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            indiceBullet = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            indiceBullet = 3;
        }

        // Aqui vou fazer a referencia da imagem para quando o tiro for dado e estiver recarregando

        if (disparo)
        {
            Normalrocket.fillAmount = 0;
            Debug.Log("Hello World!");
        }

        //Aqui vou fazer o script da recarga

        if(Normalrocket.fillAmount == 0)
        {
            Normalrocket.fillAmount += Time.time;
        }

        //Até aqui

        if (disparo)
        {
            Debug.Log("Disparado");
            Disparo();
            timer = 5;
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void Disparo()
    {
        if (Normalrocket.fillAmount >= 1)
        {
            Instantiate(Bullets[indiceBullet], transform.position, transform.rotation);
        }
    }

    public void Fire(InputAction.CallbackContext value)
    {
        disparo = value.ReadValueAsButton();
    }

    public void Selection(InputAction.CallbackContext value)
    {
        Debug.Log($"Essa tecla foi pressionada {value.control.name}");

        if(value.control.displayName == "1")
        {
            indiceBullet = 0;
        }
        else if(value.control.displayName == "2")
        {
            indiceBullet = 1;
        }
        else if(value.control.displayName == "3")
        {
            indiceBullet = 2;
        }
        else if(value.control.displayName == "4")
        {
            indiceBullet = 3;
        }
        else if(value.control.name == "Left Shoulder")
        {
            if(indiceBullet > 0)
            {
                indiceBullet = value.ReadValue<int>();
            }
        }
        else if (value.control.name == "rightShoulder")
        {
            if(indiceBullet < 3)
            {
                indiceBullet = value.ReadValue<int>();
            }
        }
    }
}
