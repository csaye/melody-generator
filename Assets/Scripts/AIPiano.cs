using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPiano : MonoBehaviour
{
    [Header("Attributes")]
    [Range(0, 1)] public float delay;
    [Range(0, 1)] public float variation;

    [Header("Notes")]
    public List<AudioClip> notes;

    [Header("References")]
    public AudioSource audioSource;

    private bool playing = false;
    
    private Coroutine cor;

    private int maxVariation;

    void Start()
    {
        maxVariation = (int)(variation * notes.Count);
        
        // Max variation failsafe
        if (maxVariation < 0)
        {
            maxVariation = 0;
        }
        if (maxVariation > notes.Count - 1)
        {
            maxVariation = notes.Count - 1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            playing = !playing;

            if (playing)
            {
                cor = StartCoroutine(playNote());
            }
            else
            {
                StopCoroutine(cor);
            }
        }
    }

    private IEnumerator playNote()
    {
        // Begin on random note
        int index = Random.Range(0, notes.Count - 1);

        while (true)
        {
            audioSource.clip = notes[index];
            audioSource.Play();
            index = modifyIndex(index);
            yield return new WaitForSeconds(delay);
        }
    }

    private int modifyIndex(int index)
    {
        index += Random.Range(maxVariation * -1, maxVariation);

        // Index failsafe
        if (index < 0)
        {
            index = 0;
        }
        if (index > notes.Count - 1)
        {
            index = notes.Count - 1;
        }

        return index;
    }
}
