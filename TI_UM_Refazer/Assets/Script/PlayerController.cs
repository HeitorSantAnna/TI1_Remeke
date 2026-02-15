using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] float xptotal = 100, xp, str, agi = 900, vit, armor, level = 1;

    [SerializeField] Transform cam;

    public static string playerName;

    public PlayerInfo playerData;

    [SerializeField] float forceJump = 100;

    [SerializeField] Vector2 move, roda;

    [SerializeField] TMP_Text dados;

    [SerializeField] Vector3 mover;

    [SerializeField] float forceMagnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(xp == xptotal)
        {
            xp = 0;
            xptotal *= 2;
            level++;
        }
    }

    void FixedUpdate()
    {

        mover = (transform.forward * move.y) * Time.fixedDeltaTime;

        transform.position += mover * agi;

        dados.text = $" Level: {level}\n XP: {xp} \n Str: {str} \n Agi: {agi / 100} \n Vit: {vit} \n Armor: {armor}";

        transform.Rotate(0, roda.x, 0);
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext value)
    {
        rb.AddForce(Vector3.up * forceJump);
    }

    public void Rodar(InputAction.CallbackContext value)
    {
        roda = value.ReadValue<Vector2>();
    }

    public void Sincronize()
    {
        playerData = new PlayerInfo();

        playerData.xp = xp;
        playerData.str = str;
        playerData.agi = agi;
        playerData.vit = vit;
        playerData.armor = armor;
        playerData.level = level;
        playerData.xptotal = xptotal;
        playerData.position = transform.position;
        playerData.playerName = playerName;
    }

    public void Load(PlayerInfo data)
    {
        playerData = new PlayerInfo();

        playerData = data;
        xp = playerData.xp;
        xptotal = playerData.xptotal;
        str = playerData.str;
        agi = playerData.agi;
        vit = playerData.vit;
        armor = playerData.armor;
        level = playerData.level;
        transform.position = playerData.position;
        playerName = playerData.playerName;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;

        forceMagnitude = collisionForce.magnitude;

        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(forceMagnitude * str > EnemyController.armor)
            {
                EnemyController.life--;
            }
            else
            {
                vit--;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("up"))
        {
            int rdn = Random.Range(0, 5);

            if(rdn == 0)
            {
                xp += 10;
                Destroy(other.gameObject);
            }
            else if(rdn == 1)
            {
                str++;
                Destroy(other.gameObject);
            }
            else if(rdn == 2)
            {
                agi += 10;
                Destroy(other.gameObject);
            }
            else if(rdn == 3)
            {
                vit++;
                Destroy(other.gameObject);
            }
            else if(rdn == 4)
            {
                armor++;
                Destroy(other.gameObject);
            }
        }

        if(other.gameObject.CompareTag("Coletavel"))
        {
            UIController.coletados++;
            Destroy(other.gameObject);
        }
    }
}
