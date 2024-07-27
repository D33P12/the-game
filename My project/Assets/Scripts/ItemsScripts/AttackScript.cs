using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private Transform fireSpawnPoint; 
    [SerializeField] private GameObject firePrefab; 
    [SerializeField] private float fireSpeed = 10f;

    private void OnEnable()
    {
        inputManager.onAttack += OnAttack;
    }

    private void OnDisable()
    {
        inputManager.onAttack -= OnAttack;
    }

    private void OnAttack(bool shoot)
    {
        if (shoot)
        {
            
            var bullet = Instantiate(firePrefab, fireSpawnPoint.position, fireSpawnPoint.rotation);

            
            var bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = fireSpawnPoint.forward * fireSpeed;
            }

            
            if (fireSound != null)
            {
                fireSound.Play();
            }
        }
    }

}
