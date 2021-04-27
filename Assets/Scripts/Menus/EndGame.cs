using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<EndGameMenu>().GameOver();
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }
}
