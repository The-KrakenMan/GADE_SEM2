using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour
{
    public Timer CheckpointTime;
    public GameObject WinScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("CheckPoint_Race");
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
            
        if (other.gameObject.tag == "Player")
        {
            

            if (other.GetComponent<Player>().CheckPointsCleared == 9)
            {
                Win();
            }
            else
            {
                other.GetComponent<Track_Manager>().CheckpointHIT();
                CheckpointTime.CheckpointTimerUpdate();
                other.GetComponent<Player>().CheckPointsCleared++;
            }
            
            Destroy(this.gameObject);
        }
        
    }

    void Win()
    {
        CheckpointTime.Timertext.text = "You Win";
    }
}
