using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StartButtFunc : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToSceneOne()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.setName(s);
        SceneManager.LoadScene("LV1 Oranges");
    }
}
