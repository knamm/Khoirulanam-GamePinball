using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;
    public float length;

    public Transform target;
    private Vector3 _defaultPosition;

    public bool hasTarget { get { return target != null; } }

    // Start is called before the first frame update
    void Start()
    {
        _defaultPosition = transform.position;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget)
        {
            Vector3 targetTocameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetTocameraDirection * length);

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTransform, float targetLength)
    {
        StopAllCoroutines();

        target = targetTransform;
        length = targetLength;
    }

    public void GoBackToDefault()
    {
        StopAllCoroutines();
        target = null;
        StartCoroutine(MovePosition(_defaultPosition, returnTime));
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0f, 1f, timer/time));
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
