using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    [SerializeField] GameObject[] Bullets = new GameObject[4];
    [SerializeField] int indiceBullet = 0;
    [SerializeField] float timer = 0;

    [SerializeField] bool disparo;

    //Aqui vou colocar uma referencia da imagem, o tiro normal ia já ficar disponivel e o resto (quando ficarem disponiveis) iniciaram carregando com uma imagem preto e branco e começa a carregar quando carregar vai dar uma piscada e um som que indica que está disponivel

    [SerializeField] Image[] Rocketcooldown = new Image[4];

    //Rocket Thunder
    //Ele causara um curto que cancelara todas as habilidades e também travará as naves

    //Rocket Venom
    //Ele causa um dano curto ao longo do tempo e também desacelera a vave afetada

    //Rocket Fire
    //Ele causa dano de queimadura em area, se uma nave morreria ao entrar em contato com esse foguete/com o efeito de queimadura ele explode de novo e espalha fogo (agora como tem fogo no espaço onde não tem oxigenio já é outra história kkkkkkk

    void Start()
    {
        Rocketcooldown[0].fillAmount = 1;
    }

    void Update()
    {
        if (disparo)
        {
            Disparo();
        }

        if(Rocketcooldown[0].fillAmount < 1)
        {
            Rocketcooldown[0].fillAmount += Time.deltaTime;
        } 
        
        if(Rocketcooldown[1].fillAmount < 1)
        {
            Rocketcooldown[1].fillAmount += Time.deltaTime / 2;
        }

        if (Rocketcooldown[2].fillAmount < 1)
        {
            Rocketcooldown[2].fillAmount += Time.deltaTime / 3;
        }

        if (Rocketcooldown[3].fillAmount < 1)
        {
            Rocketcooldown[3].fillAmount += Time.deltaTime / 4;
        }
    }

    void Disparo()
    {
        if (Rocketcooldown[indiceBullet].fillAmount >= 1)
        {
            Instantiate(Bullets[indiceBullet], transform.position, transform.rotation);

            Rocketcooldown[indiceBullet].fillAmount = 0;
        }
    }

    public void Fire(InputAction.CallbackContext value)
    {
        disparo = value.ReadValueAsButton();
    }

    public void Selection(InputAction.CallbackContext value)
    {
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
    }

    public void SelectionGamePad(InputAction.CallbackContext value)
    {
        if(!value.performed)
        {
            return;
        }

        float valor = value.ReadValue<float>();

        if(valor > 0.5f && indiceBullet != 3)
        {
            indiceBullet += 1;
        }
        else if(valor < -0.5f && indiceBullet != 0)
        {
            indiceBullet -= 1;
        }
    }
}
