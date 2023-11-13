using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;

    float totalScore;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = PlayerPrefs.GetFloat("total");
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = totalScore.ToString("00");
    }
}
