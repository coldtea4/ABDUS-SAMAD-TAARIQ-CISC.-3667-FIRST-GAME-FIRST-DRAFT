using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score = 0;
    const int DEFAULT_POINTS = 1;
    public TMPro.TextMeshProUGUI scoreText;
    public string nextSceneName;
    // Start is called before the first frame update
    void Update()
    {
        bool tagExists = GameObject.FindGameObjectsWithTag("balloon").Length > 0;
        if(!tagExists)
        {
            LoadNextScene();
        }
    }
    void Start()
    {
        score = PersistentData.Instance.getScore();
        UpdateScoreText();
    }
    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
        UpdateScoreText();
    }
    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
        PersistentData.Instance.setScore(score);
    }
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
