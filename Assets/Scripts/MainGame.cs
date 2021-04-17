using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    
    public AudioClip auBgMusic;
    public AudioClip auFailed;
    public AudioClip auFinished;
    public Text TimerText;

    AudioSource Sound;

    float Timer = 1000f;
    bool GameOver = false;
    bool Finish = false;
    bool Restarting = false;
    int PlayerLevel;
    int SelectedLevel;

    // Start is called before the first frame update
    void Start()
    {

        Sound = GetComponent<AudioSource>();
        Sound.clip = auBgMusic;
        Sound.Play();

        PlayerLevel = PlayerPrefs.GetInt("ppPlayerLevel",1);
        Debug.Log("PlayerLevel from PP = " + PlayerLevel);
        SelectedLevel = PlayerPrefs.GetInt("ppSelectedLevel",1);
        Debug.Log("SelectedLevel from PP = " + SelectedLevel);

        Debug.Log("Playing Player Level " + PlayerLevel.ToString() + " Selected Level " + SelectedLevel.ToString());

        switch (SelectedLevel)
        {
            case 1:
                Timer = 18f;
                break;
            case 2:
                Timer = 35f;
                break;
            case 3:
                Timer = 45f;
                break;
            case 4:
                Timer = 140f;
                break;
            case 5:
                Timer = 100f;
                break;
            case 6:
                Timer = 20f;
                break;
            case 7:
                Timer = 35f;
                break;
            case 8:
                Timer = 30f;
                break;
            case 9:
                Timer = 125f;
                break;
            case 10:
                Timer = 200f;
                break;
            case 11:
                Timer = 200f;
                break;
            case 12:
                Timer = 200f;
                break;
            default:
                Timer = 55f;
                break;
        }

        SceneManager.LoadSceneAsync("Level" + SelectedLevel.ToString());
    }

    void Update()
    {
        if (!Restarting)
        {
            if (!Finish)
            {
                if (Timer < 0)
                {
                    TimerText.text = "Time is Over!";
                    GameOver = true;
                    Timer = 5f;
                    Restarting = true;
                    Sound.Stop();
                    Sound.PlayOneShot(auFailed);
                }
                else
                {
                    Timer -= Time.deltaTime;
                    TimerText.text = "Level " + SelectedLevel + " : Reach The Lighthouse in " + Timer.ToString("0") + " second(s)";
                    //Debug.Log("Level " + PlayerLevel + " : Reach Monas in " + Timer.ToString() + " second(s)");
                }
            }
            else
            {
                TimerText.text = "Congratulations! You're ready to move to the next level";
                Timer = 5f;
                Restarting = true;

                if (PlayerLevel == SelectedLevel)
                {
                    if (PlayerLevel < 15) {
                        PlayerLevel += 1;
                        SelectedLevel += 1;
                    }

                    PlayerPrefs.SetInt("ppPlayerLevel", PlayerLevel);
                    PlayerPrefs.SetInt("ppSelectedLevel", SelectedLevel);
                }
                else
                {
                    PlayerPrefs.SetInt("ppSelectedLevel", SelectedLevel + 1);
                }

                GameOver = true;
            }
        }
        else
        {
            if (Timer < 0)
            {
                if(GameOver)
                    SceneManager.LoadSceneAsync("Menu");
                else
                    SceneManager.LoadSceneAsync("SceneTransition");
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "finisharea")
        {
            if (!GameOver) {
                Finish = true;
                Sound.Stop();
                Sound.PlayOneShot(auFinished);
            }
        }
        else if (other.name == "failarea")
        {
            if (!GameOver) {
                TimerText.text = "Oops. That's okay, Try again!";
                GameOver = true;
                Timer = 5f;
                Restarting = true;
                Sound.Stop();
                Sound.PlayOneShot(auFailed);
            }
        }
      }
}
