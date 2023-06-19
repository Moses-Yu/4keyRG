using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public TMP_Text text;
    public Notes notes;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("{0:N3}", notes.speed);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (notes.start)
                notes.start = false;
            else
                notes.start = true;
            print(notes.start);
        }


        if(Input.GetKeyDown(KeyCode.W)){
            notes.speed -= 0.01f;
            notes.enabled = false;
            notes.enabled = true;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            notes.speed += 0.01f;
            notes.enabled = false;
            notes.enabled = true;
        }
    }
}
