using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setScore(int s)
    {
        playerScore = s;
    }

    public void setName(string n)
    {
        playerName = n;
    }

    public string getName()
    {
        return playerName;
    }

    public int getScore()
    {
        return playerScore;
    }
}
