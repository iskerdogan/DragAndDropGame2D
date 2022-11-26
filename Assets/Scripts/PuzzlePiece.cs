using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip pickUpClip;

    [SerializeField]
    private AudioClip dropClip;

    private bool dragging;
    private bool placed;
    private Vector2 offset;
    private Vector2 originalPos;
    private PuzzleSlot _slot;

    public void Init(PuzzleSlot slot)
    {
        spriteRenderer.sprite = slot.spriteRenderer.sprite;
        _slot = slot;
    }

    private void Awake() => originalPos = transform.position;

    private void FixedUpdate()
    {
        if (placed) return;
        if (!dragging) return;

        var mousePos = GetMousePos();
        transform.position = mousePos - offset;
    }

    private void OnMouseDown()
    {
        dragging = true;
        source.PlayOneShot(pickUpClip);
        offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp() 
    {
        if (placed) return;
        if (Vector2.Distance(transform.position, _slot.transform.position) < 2)
        {
            transform.position = _slot.transform.position;
            _slot.Placed();
            placed = true;
        }
        else 
        {
            transform.position = originalPos;
            dragging = false;
            source.PlayOneShot(dropClip);
        }
    } 

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
