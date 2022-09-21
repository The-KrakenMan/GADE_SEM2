using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue_Man : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject SceneDialogue;
    int Counter = 0;
    public void OnClick()
    {
 
        if (Counter < 5)
        {
            SceneDialogue.GetComponent<JSON_Reader>().NextDialogue();
            Counter++;
        }
        else
        {
            SceneManager.LoadScene("Check Point_Race");
        }
        
    }

    public void Activate()
    {
        this.Activate();
    }
}
