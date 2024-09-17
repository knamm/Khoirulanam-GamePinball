using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    public Color onLauncher;
    public Color offLauncher;

    private bool _isHold = false;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }
    
    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !_isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        _isHold = true;
        float force = 0f;
        float timeHold = 0f;

        while (Input.GetKey(input))
        {
            _renderer.material.color = onLauncher;
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(-Vector3.forward * force);
        _isHold = false;
        _renderer.material.color = offLauncher;
    }
}
