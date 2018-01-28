using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class SceneController : MonoBehaviour {

    /*private void Start()
    {
        VuforiaRuntime.Instance.InitVuforia();
        VuforiaBehaviour.Instance.enabled = true;
    }*/


    public void LoadLevel(string scene)
    {
        if(scene.Equals("Game"))
        {
            //Turn off Vuforia
            VuforiaBehaviour.Instance.enabled = false;
            VuforiaRuntime.Instance.Deinit();
        }
        else if(scene.Equals("Main"))
        {
            //Turn on Vuforia
            VuforiaBehaviour.Instance.enabled = true;
        }
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
