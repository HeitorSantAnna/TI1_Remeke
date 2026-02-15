using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] GameObject power;

    [SerializeField] float time, delay;

    [SerializeField] float rdnx, rdnz;

    void Start()
    {
        InvokeRepeating("Ups", time, delay);
    }

    void Update()
    {
        
    }

    void Ups()
    {
        rdnx = Random.Range(1, 999);

        rdnz = Random.Range(1, 999);

        Instantiate(power, transform.position = new Vector3(rdnx, 0.5f, rdnz), transform.rotation);
    }
}
