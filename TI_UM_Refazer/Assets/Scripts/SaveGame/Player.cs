using UnityEngine;

public class Player : MonoBehaviour
{
    public int xp, str, agi, vit, armor, level;
    public float speed;
    public string playerName;
    public PlayerInfo playerData;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.position += (transform.right * h + transform.forward * v) * speed * Time.deltaTime;
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

        playerData.position = transform.position;
        playerData.playerName = playerName;
    }

    public void Load(PlayerInfo data)
    {
        playerData = new PlayerInfo();
        playerData = data;
        /*xp = playerData.xp;
        str = playerData.str;
        agi = playerData.agi;
        vit = playerData.vit;
        armor = playerData.armor;
        level = playerData.level;
        speed = playerData.speed;*/
        transform.position = playerData.position;
        playerName = playerData.playerName;
    }
}
