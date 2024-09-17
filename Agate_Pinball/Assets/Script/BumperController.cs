using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;
    public float score;
    
    private Renderer _renderer;
    private Animator _animator;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = color;

        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider  == bola)
        {
            Rigidbody rb = bola.GetComponent<Rigidbody>();
            rb.velocity *= multiplier;

            _animator.SetTrigger("hit");
            audioManager.PlayBumperSFX(collision.transform.position);
            vfxManager.PlayVFXBumper(collision.transform.position);
            scoreManager.AddScore(score);
        }
    }
}
