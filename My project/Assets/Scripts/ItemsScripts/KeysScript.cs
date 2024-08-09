
using TMPro;
using UnityEngine;

public class KeysScript : MonoBehaviour
{
    public TextMeshProUGUI Count;
    public int Keys { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GameManager.Keys += 1;

            Destroy(gameObject);

            Count.GetComponent<TextMeshProUGUI>().text = "Keys: " + GameManager.Keys;


        }
    }

}
