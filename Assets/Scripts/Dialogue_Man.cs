using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue_Man : MonoBehaviour
{
    // Start is called before the first frame update

   
    int Counter = 0;
    public void OnClick()
    {
        Debug.Log("Clicked");
        Counter++;
        if (Counter  < 5)
        {
            this.GetComponent<JSON_Reader>().NextDialogue();
        }
        else
        {
            SceneManager.LoadScene("CheckPoint_Race");
        }
        
    }

   
}
