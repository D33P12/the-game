using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    AudioSource fireSound;

    public Transform fireSpawnPoint; // point where bullet spawns
    public GameObject firePrefab;// object to be used as killing bullet
   
    public float fireSpeed = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            var bullet = Instantiate(firePrefab, fireSpawnPoint.position,fireSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = fireSpawnPoint.forward * fireSpeed;
            //fireSound.Play();
        }

    }

}
