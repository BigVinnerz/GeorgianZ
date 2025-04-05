using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnSceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(1);
    }
}