using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] public float phealth;
    [SerializeField] public float pmaxhealth;
    [SerializeField] public Image healthCircle;
    

    void Start()
    {
        pmaxhealth = phealth;
        UpdateHealthUI();
    }

    void Update()
    {
        UpdateHealthUI();
      
    }

    public void AddHealth(int hamount)
    {
        
        phealth = Mathf.Clamp(phealth + hamount, 0, pmaxhealth);
   
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthCircle.fillAmount = Mathf.Clamp(phealth / pmaxhealth, 0, 1);
    }
   
}
