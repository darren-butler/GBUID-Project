using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    private int score;
    [SerializeField] private GameObject scoreTextObject;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    public void UpdateScore(int gemValue)
    {
        score += gemValue;
        scoreTextObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        Debug.Log(gemValue);
    }
}
