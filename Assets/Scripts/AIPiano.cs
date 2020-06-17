using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPiano : MonoBehaviour
{
    [Header("Attributes")]
    [Range(0.1f, 2)] public float speed;

    [Header("Notes")]
    public List<AudioClip> notes;

    [Header("References")]
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playNote());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playNote()
    {
        for (int i = 0; i < notes.Count; i++)
        {
            yield return new WaitForSeconds(speed);
            audioSource.clip = notes[i];
            audioSource.Play();
        }
    }
}
