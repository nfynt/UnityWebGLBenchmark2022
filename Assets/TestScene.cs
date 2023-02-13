using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
    public Text fpsTxt;
    public Text sceneTxt;
    
    private static int currSceneInd = 0;

    private void Start()
    {
        currSceneInd = SceneManager.GetActiveScene().buildIndex;
        sceneTxt.text = "Scene: " + SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if(fpsTxt!=null)
        {
            fpsTxt.text = "Fps: " + ((int)(1f / Time.unscaledDeltaTime)).ToString();
        }
    }

    public void SwitchToNextScene()
    {
        SwitchScene(++currSceneInd);
    }

    public void SwitchToPrevScene()
    {
        SwitchScene(--currSceneInd);
    }

    private void SwitchScene(int ind)
    {
        if (ind < 0)
            ind = SceneManager.sceneCountInBuildSettings - 1;
        
        if (ind >= SceneManager.sceneCountInBuildSettings)
            ind = 0;

        SceneManager.LoadScene(ind, LoadSceneMode.Single);
    }
}
