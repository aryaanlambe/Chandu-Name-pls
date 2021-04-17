using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starter : MonoBehaviour
{
    public string nextscene = "";
    float countDown = 1f;
    bool triggered = false;

    void FixedUpdate()
    {
        if (countDown > 0)
            countDown -= Time.deltaTime;
        else {
            if (!triggered)
            {
                triggered = true;
                SceneManager.LoadSceneAsync(nextscene);

            }
        }

    }
}
