using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(transform.forward * 2);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("BulletE"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
