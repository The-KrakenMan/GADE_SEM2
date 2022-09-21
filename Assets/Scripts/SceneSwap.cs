using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dialogue;
    public void StartDialogue()
    {
        Dialogue.SetActive(true);
    }

    public void Start()
    {
        
    }

    public void GoToChoose()
    {
        SceneManager.LoadScene("Race_Choosing");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    // Update is called once per frame

}
