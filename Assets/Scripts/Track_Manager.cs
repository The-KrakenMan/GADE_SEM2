using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Manager : MonoBehaviour
{
    public Stack<CheckPoints> numbers = new Stack<CheckPoints>();
    public CheckPoints[] ger = new CheckPoints[9];
    public bool Pcollision = false;
   
    // Start is called before the first frame update
    void Start()
    {
        CheckpointStart();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CheckpointStart()
    {
       CheckPoints Start = new CheckPoints();

        
        numbers.Push(ger[8]);
        numbers.Push(ger[7]);
        numbers.Push(ger[6]);
        numbers.Push(ger[5]);
        numbers.Push(ger[4]);
        numbers.Push(ger[3]);
        numbers.Push(ger[2]);
        numbers.Push(ger[1]);
        numbers.Push(ger[0]);

        Start = numbers.Pop();
        Start.gameObject.SetActive(true);
        
    }

    public void CheckpointUpdate()
    {

    }

    public void CheckpointHIT()
    {
        CheckPoints Next = new CheckPoints();
        Next = numbers.Pop();
        Next.gameObject.SetActive(true); 
    }
}
