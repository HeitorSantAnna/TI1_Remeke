using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    float delay = 0.5f;

    [SerializeField] GameObject bullet;

    void Start()
    {
        InvokeRepeating("Fire", 1, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
