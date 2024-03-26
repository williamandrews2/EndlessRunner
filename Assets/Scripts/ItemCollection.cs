using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] Text coinsText;
    private int coinTotal = 0;

    void Start()
    {
        updateCoins();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin")){

            Destroy(other.gameObject);   
            
            coinTotal++;

            updateCoins();
        }
    }

    void updateCoins()
    {
        coinsText.text = "Coins: " + coinTotal;
    }
}
