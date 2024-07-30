using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAmmo : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 10; 

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has an AttackScript component
        AttackScript attackScript = other.GetComponent<AttackScript>();
        if (attackScript != null)
        {
            attackScript.AddAmmo(ammoAmount); 
            Destroy(gameObject); 
        }
    }
}
