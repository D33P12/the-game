using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private Transform fireSpawnPoint; 
    [SerializeField] private GameObject firePrefab; 
    [SerializeField] private float fireSpeed = 20f;

    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI noammoText;

    [SerializeField] private float displayDuration = 5f;
    private Coroutine hideCoroutine;
    private int currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo; 
        UpdateAmmoDisplay();
    }
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
        if (shoot && currentAmmo >= 0)
        {
            UpdateAmmoDisplay();
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

            if (currentAmmo == 0)
            {
                noammoText.text = "No Flames Left";
            }

            currentAmmo--;
        }
       

    }
    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + 1 + amount, 0, maxAmmo);
        Debug.Log("Ammo picked up! Current ammo: " + currentAmmo);
        UpdateAmmoDisplay();

        if (currentAmmo >= 0)
        {
            noammoText.text = "Flames added";
        }
      

    }
    private void UpdateAmmoDisplay()
    {
        if (ammoText != null)
        {
            ammoText.text = $"Flames: {currentAmmo}/{maxAmmo}";
          
        }
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }
        hideCoroutine = StartCoroutine(HideAmmoText());

    }
    private IEnumerator HideAmmoText()
    {
        yield return new WaitForSeconds(displayDuration);
        noammoText.enabled = false;
    }
}
