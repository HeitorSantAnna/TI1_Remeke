using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMoviment : MonoBehaviour
{

    [SerializeField] Transform enemy;

    [SerializeField] int life = 3;

    [SerializeField] Renderer fire;

    [SerializeField] Material firematerial;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("NBullet"))
        {
            GetComponent<Renderer>().material = firematerial;
        }
    }
}
