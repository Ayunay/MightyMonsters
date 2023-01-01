using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ChangeSceneNumber(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ChangeSceneName(string scene)
    {
        SceneManager.LoadScene($"{scene}");
    }

    public void Exit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}
