using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private int gemValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>().UpdateScore(gemValue);
        //GameObject.FindGameObjectWithTag("GameController").GetComponent<SoundController>().PlayCoinSound();
        Destroy(gameObject);
    }
}
