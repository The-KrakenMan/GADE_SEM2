using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JSON_Reader : MonoBehaviour
{
    public TextAsset jsonFile;
    private Queue<string> SceneDialogue;
    public TextMeshProUGUI Output;
    // Start is called before the first frame update


    void Start()
    {
        SetDialogue();
        NextDialogue();
     
    }

    private void SetDialogue()
    {
        NPC_DIALOGUE LineRead = JsonUtility.FromJson<NPC_DIALOGUE>(jsonFile.text);
        SceneDialogue = new Queue<string>();
        for (int i = 0; i < 5; i++)
        {
            SceneDialogue.Enqueue(LineRead.npcCharacters[i].npcName + ": \n" + LineRead.npcCharacters[i].Dialogue);
        }

        Output.text = SceneDialogue.Peek();
        SceneDialogue.Dequeue();
    }

    public void NextDialogue()
    {
        Output.text = SceneDialogue.Peek();
        SceneDialogue.Dequeue();
    }

    // Update is called once per frame
    
}
