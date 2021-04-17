using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Text SeLev;
    int UnlockedLevel;
    int SelectedLevel;

    // Start is called before the first frame update
    void Start()
    {
        UnlockedLevel = PlayerPrefs.GetInt("ppPlayerLevel", 1);
        SeLev.text = UnlockedLevel.ToString();
        SelectedLevel = UnlockedLevel;
        PlayerPrefs.SetInt("ppSelectedLevel", SelectedLevel);
    }

    // Update is called once per frame
    void Update()
    {
        SeLev.text = SelectedLevel.ToString();
    }

    public void Prev()
    {
        if (SelectedLevel > 1)
        {
            SelectedLevel -= 1;
            PlayerPrefs.SetInt("ppSelectedLevel", SelectedLevel);
            Debug.Log("Selected Level : " + SelectedLevel);
            Debug.Log("Selected Level from PP : " + PlayerPrefs.GetInt("ppSelectedLevel", 1));
        }
    }

    public void Next()
    {
        if (SelectedLevel < UnlockedLevel)
        {
            SelectedLevel += 1;
            PlayerPrefs.SetInt("ppSelectedLevel", SelectedLevel);
            Debug.Log("Selected Level : " + SelectedLevel);
            Debug.Log("Selected Level from PP : " + PlayerPrefs.GetInt("ppSelectedLevel", 1));
        }
    }
}
