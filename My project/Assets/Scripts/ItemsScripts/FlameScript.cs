using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    public float life = 9;

    void Awake()
    {
        Destroy(gameObject, life); // Destroy bullet after 'life' seconds
    }
    public LayerMask enemyLayer;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            
            Destroy(other.gameObject);

        }
    }

}
