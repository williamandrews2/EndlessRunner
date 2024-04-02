using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] Text coinsText;
    private int coinTotal = 0;
    private bool isCollidingWithCoin = false;

    void Start()
    {
        //updateCoins();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin") && !isCollidingWithCoin)
        {
            isCollidingWithCoin = true;
            
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;

            Debug.Log("Coin is Destroyed!");

            coinTotal++;

            updateCoins();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            isCollidingWithCoin = false;
        }
    }

    void updateCoins()
    {
        coinsText.text = "Coins: " + coinTotal;
    }
}
