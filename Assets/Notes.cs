using System;
using System.Collections;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public bool start = false;
    public GameObject shortNote;
    public GameObject longNote;
    public float speed = 1 / 60;
    public Transform[] lanes = { };
    private ArrayList notePositionS;
    private ArrayList notePositionL;
    private float sectorSize = 0.14165f;
    public float skipTo = 65f;
    public GameObject longNotePos;
    
    private ArrayList song1 = new ArrayList()
    {
        new ArrayList() { 71.26, 2, 'l', 2 },
        new ArrayList() { 71.26, 4, 'l', 2 },
        new ArrayList() { 71.5433, 3, 's' },
        new ArrayList() { 71.68495, 2, 's' },
        new ArrayList() { 71.8266, 1, 's' },
        new ArrayList() { 72.1099, 2, 'l', 4 },
        new ArrayList() { 72.1099, 4, 'l', 4 },
        new ArrayList() { 72.6765, 1, 's' },
        new ArrayList() { 73.2431, 3, 's' },
        new ArrayList() { 73.5264, 1, 'l', 2 },
        new ArrayList() { 73.5264, 3, 'l', 2 },
        new ArrayList() { 73.8097, 4, 's' },
        new ArrayList() { 73.95135, 3, 's' },
        new ArrayList() { 74.3763, 2, 'l', 2 },
        new ArrayList() { 74.6596, 3, 'l', 2 },
        new ArrayList() { 74.9429, 1, 'l', 2 },
        new ArrayList() { 75.2262, 2, 's' },
        new ArrayList() { 75.2262, 4, 'l', 4 },
        new ArrayList() { 75.7928, 1, 'l', 2 },
        new ArrayList() { 75.7928, 3, 'l', 2 },
        new ArrayList() { 76.0761, 4, 's' },
        new ArrayList() { 76.21775, 3, 's' },
        new ArrayList() { 76.3594, 2, 's' },
        new ArrayList() { 76.6427, 1, 'l', 4 },
        new ArrayList() { 76.6427, 3, 'l', 4 },
        new ArrayList() { 77.2093, 2, 's' },
        new ArrayList() { 77.4926, 4, 's' },
        new ArrayList() { 77.7759, 2, 's' },
        new ArrayList() { 78.0592, 1, 's' },
        new ArrayList() { 78.0592, 4, 'l', 2 },
        new ArrayList() { 78.3425, 3, 's' },
        new ArrayList() { 78.48415, 4, 's' },
        new ArrayList() { 78.6258, 2, 's' },
        new ArrayList() { 78.9091, 1, 'l', 2 },
        new ArrayList() { 79.1924, 2, 'l', 2 },
        new ArrayList() { 79.4757, 3, 'l', 2 },
        new ArrayList() { 79.759, 4, 's' },
        new ArrayList() { 79.759, 1, 'l', 4 }
    };

    // { 71.26, 2, 'l', 2 }
    // Start is called before the first frame update
    void OnEnable()
    {
        notePositionS = new ArrayList();
        notePositionL = new ArrayList();

        Transform[] notes = GetComponentsInChildren<Transform>();
        if (notes.Length > 0)
        {
            for (int i = 0; i < notes.Length - 1; i++)
            {
                notes[i] = notes[i + 1];
            }
            Array.Resize(ref notes, notes.Length - 1);

            foreach (Transform item in notes)
            {
                Destroy(item.gameObject);
            }
        }

        foreach (ArrayList note in song1)
        {
            float time = Convert.ToSingle(note[0]);
            int lane = (int)note[1] - 1;
            float xPos = lanes[lane].position.x;
            if ((char)note[2] == 's')
            {
                Vector2 temp = new Vector2(xPos, speed * time * 60);
                notePositionS.Add(temp);
            }
            else if ((char)note[2] == 'l')
            {
                Vector3 temp = new Vector3(xPos, speed * time * 60, 0);
                // notePositionL.Add(temp);
                GameObject startPos =  Instantiate(longNotePos, temp, Quaternion.identity, transform);

                temp = new Vector3(xPos, speed * (time + sectorSize * (int)note[3]) * 60, 0);
                // notePositionL.Add(temp);

                GameObject endPos = Instantiate(longNotePos, temp, Quaternion.identity, transform);
                
                Transform[] pos = {startPos.transform, endPos.transform};
                
                GameObject longN = Instantiate(longNote, transform);

                longN.GetComponent<longNote>().SetUpLine(startPos.transform, endPos.transform);
                


                // for (float i = 0; i <= (int)note[3]; i += 0.2f)
                // {
                //     temp = new Vector2(xPos, speed * (time + sectorSize * i) * 60);
                //     notePositionL.Add(temp);
                // }
            }
        }

        transform.position = new Vector2(0, 0);

        foreach (Vector2 position in notePositionS)
        {
            Instantiate(shortNote, position, Quaternion.Euler(0, 0, 0), transform);
        }
        // foreach (Vector2 position in notePositionL)
        // {
        //     Instantiate(longNote, position, Quaternion.Euler(0, 0, 0), transform);
        // }

        transform.position = new Vector2(0, -speed * 60 + -speed * 60 * skipTo);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {
            transform.Translate(new Vector2(0, -speed));
        }
        else
        {
            transform.position = new Vector2(0, -speed * 60 + -speed * 60 * skipTo);
        }
    }
}
