using UnityEngine;

public class FireAmmo : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 10; 

    private void OnTriggerEnter(Collider other)
    {

        AttackScript attackScript = other.GetComponent<AttackScript>();
        if (attackScript != null)
        {
            attackScript.AddAmmo(ammoAmount); 
            Destroy(gameObject); 
        }
    }
}
