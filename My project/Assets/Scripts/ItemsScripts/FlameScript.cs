
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    public float life = 9;
    public float damage = 30f;

    void Awake()
    {
        Destroy(gameObject, life); 
    }
    public LayerMask enemyLayer;

    void OnTriggerEnter(Collider other)
    {
        EnemyAI enemyHealth = other.GetComponent<EnemyAI>();
       
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
