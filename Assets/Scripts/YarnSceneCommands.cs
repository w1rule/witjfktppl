using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnSceneCommands : MonoBehaviour
{
    private static DialogueRunner runner;

    void Start()
    {
        runner = FindObjectOfType<DialogueRunner>();
    }

    [YarnCommand("load_scene")]
    public static void LoadScene(string sceneName)
    {
        runner.SaveStateToPersistentStorage("yarnsave");
        SceneManager.LoadScene(sceneName);
    }
}