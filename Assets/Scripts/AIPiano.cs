using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPiano : MonoBehaviour
{
    [Header("Attributes")]
    [Range(0, 1)] public float delay;
    [Range(0, 36)] public int variation;
    [Range(0, 36)] public int minNote;
    [Range(0, 36)] public int maxNote;

    [Header("Notes")]
    public List<AudioClip> notes;

    [Header("References")]
    public AudioSource audioSource;
    public TMPro.TextMeshProUGUI noteScroller;

    private bool playing = false;
    
    private Coroutine cor;

    void Update()
    {
        // Minimum note failsafe
        if (minNote > maxNote)
        {
            minNote = maxNote;
        }

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
        int index = Random.Range(minNote, maxNote + 1);

        while (true)
        {
            audioSource.clip = notes[index];
            audioSource.Play();
            noteScroller.text = noteScroller.text + " " + getNoteName(index);
            index = modifyIndex(index);
            yield return new WaitForSeconds(delay);
        }
    }

    private int modifyIndex(int index)
    {
        index += Random.Range(variation * -1, variation + 1);

        // Index failsafe
        if (index < minNote)
        {
            index = minNote;
        }
        if (index > maxNote)
        {
            index = maxNote;
        }

        return index;
    }

    private string getNoteName(int index)
    {
        switch (index)
        {
            case 0: return "C2";
            case 1: return "C#2";
            case 2: return "D2";
            case 3: return "D#2";
            case 4: return "E2";
            case 5: return "F2";
            case 6: return "F#2";
            case 7: return "G2";
            case 8: return "G#2";
            case 9: return "A2";
            case 10: return "A#2";
            case 11: return "B2";
            case 12: return "C3";
            case 13: return "C#3";
            case 14: return "D3";
            case 15: return "D#3";
            case 16: return "E3";
            case 17: return "F3";
            case 18: return "F#3";
            case 19: return "G3";
            case 20: return "G#3";
            case 21: return "A3";
            case 22: return "A#3";
            case 23: return "B3";
            case 24: return "C4";
            case 25: return "C#4";
            case 26: return "D4";
            case 27: return "D#4";
            case 28: return "E4";
            case 29: return "F4";
            case 30: return "F#4";
            case 31: return "G4";
            case 32: return "G#4";
            case 33: return "A4";
            case 34: return "A#4";
            case 35: return "B4";
            case 36: return "C5";
            
            default: return null;
        }
    }
}
