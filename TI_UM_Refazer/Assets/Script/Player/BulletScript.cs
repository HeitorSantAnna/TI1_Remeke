using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] Camera cam;

    void Start()
    {
        Destroy(gameObject, 3f);

        cam = Camera.main;
    }

    void Update()
    {
        transform.Translate(cam.transform.forward * 2);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
