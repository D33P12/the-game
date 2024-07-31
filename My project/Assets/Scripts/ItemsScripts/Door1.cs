using UnityEngine;

public class Door1 : MonoBehaviour
{
    [SerializeField]
    public GameObject doorSwitch;
    [SerializeField]
    public GameObject doorSwitch1;
    [SerializeField]
    public GameObject doorSwitch2;


    private void Start()
    {
        doorSwitch.SetActive(true); 
        doorSwitch1.SetActive(true); 
        doorSwitch2.SetActive(true); 
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && GameManager.Keys==3)
        {
            doorSwitch.SetActive(false); 
           
        }
        if (other.CompareTag("Player") && GameManager.Keys == 5)
        {
            doorSwitch1.SetActive(false); 

        }
        if (other.CompareTag("Player") && GameManager.Keys == 10)
        {
            doorSwitch2.SetActive(false); 

        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorSwitch.SetActive(true); 
            doorSwitch1.SetActive(true); 
            doorSwitch2.SetActive(true); 
        }
    }
}
