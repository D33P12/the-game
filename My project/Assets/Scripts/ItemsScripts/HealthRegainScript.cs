using UnityEngine;

public class HealthRegainScript : MonoBehaviour
{
    [SerializeField] private int hAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealthScript playerHealthScript = other.GetComponent<PlayerHealthScript>();
        if (playerHealthScript != null)
        {
            playerHealthScript.AddHealth(hAmount);
            Destroy(gameObject);
        }
    }
}
