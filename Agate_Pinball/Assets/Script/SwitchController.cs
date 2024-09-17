using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{
    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    public ScoreManager scoreManager;
    public float score;
    public AudioManager audioManager;
    public VFXManager vfxManager;

    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    private SwitchState _state;
    private Renderer _renderer;



    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimeStart(5));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            audioManager.PlaySwitchSFX(other.transform.position);
            Toggle(other);
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            _state = SwitchState.On;
            _renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            _state = SwitchState.Off;
            _renderer.material = offMaterial;
            StartCoroutine(BlinkTimeStart(5));
        }
    }

    void Toggle(Collider other)
    {
        if (_state == SwitchState.On)
        {
            Set(false);
            vfxManager.PlayVFXSwitchOff(other.transform.position);
            scoreManager.AddScore(score);
        }
        else
        {
            Set(true);
            vfxManager.PlayVFXSwitchOn(other.transform.position);
            scoreManager.AddScore(score);
        }
    }
    
    IEnumerator Blink(int times)
    {
        _state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            _renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            _renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
        _state = SwitchState.Off;
        StartCoroutine(BlinkTimeStart(5));
    }

    IEnumerator BlinkTimeStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
