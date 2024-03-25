using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource mainMusic;
    private void Start()
    {
        mainMusic.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOverScene");
        }            
    }
}
