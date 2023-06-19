using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public Notes notes;
    private AudioSource song1;

    // Start is called before the first frame update
    void Start()
    {
        song1 = GetComponent<AudioSource>();
        song1.time = notes.skipTo;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(notes.start){
            PlaySong();
        }
    }

    void PlaySong()
    {
        if (!song1.isPlaying)
            song1.Play();
    }

    void StopSong()
    {
        if (song1.isPlaying)
        {
            song1.Stop();
        }
    }
}
