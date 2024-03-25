using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] Text coinsText;
    int coinTotal = 0;

    private void Start()
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
