using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    int nextSceneIndex;
    int actualScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void Awake()
    {

        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        actualScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void NextWorld()
    {
        SceneManager.LoadScene(nextSceneIndex);
        Time.timeScale = 1;
    }
}
