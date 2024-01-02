using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CoinPeteca : MonoBehaviour
{

    public int ScoreValue;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound.Play();
            GameController.instance.UpdateScore(ScoreValue);
            Destroy(gameObject,0.1f);
        }
    }
}
