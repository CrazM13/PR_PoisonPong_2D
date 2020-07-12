using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChange(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
