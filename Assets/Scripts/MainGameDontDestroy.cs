using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameDontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private Scene scene;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Menu" || scene.name == "SceneTransition") {
            Destroy(this.gameObject);
        }
    }
}