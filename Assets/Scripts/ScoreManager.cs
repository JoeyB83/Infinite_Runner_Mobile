using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;

    public float scoreCount;

    public float scorePerSecond;

    public bool isScore;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        PlayerPrefs.SetFloat("total", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.grounded) return;

        scoreCount += scorePerSecond * Time.deltaTime;
        score.text = scoreCount.ToString("00");
        PlayerPrefs.SetFloat("total", scoreCount);
    }
}
