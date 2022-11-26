using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    private AudioSource source;
    
    [SerializeField]
    private AudioClip complateClip;

    public void Placed()
    {
        source.PlayOneShot(complateClip);
    }
}
