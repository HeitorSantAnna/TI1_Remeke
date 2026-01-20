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
            Destroy(gameObject);
    }
}
