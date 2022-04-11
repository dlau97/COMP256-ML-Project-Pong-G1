using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string activeScene = "";
        activeScene = SceneManager.GetActiveScene().name;
        if(Input.GetKeyDown(KeyCode.Escape) && (activeScene == "AI Play Scene" || activeScene == "Player Play Scene")){
            LoadMenuScene();
        }
        else if(activeScene == "Menu Scene"){
            QuitApplication();
        }
    }

    public void OnClickLoadAIPlayScene(){
        SceneManager.LoadScene("AI Play Scene");
    }

    public void OnClickLoadPlayerPlayScene(){
        SceneManager.LoadScene("Player Play Scene");
    }

    public void LoadMenuScene(){
        SceneManager.LoadScene("Menu Scene");
    }

    public void QuitApplication(){
        Application.Quit();
    }
}
