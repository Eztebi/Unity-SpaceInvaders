using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D collider;

    void Start()
    {
        // Obtener el SpriteRenderer del objeto al que este script está adjunto
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        // Asegurarse de que el SpriteRenderer esté inicialmente desactivado
        spriteRenderer.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collider.enabled = false;
        spriteRenderer.enabled = true;
    }
}