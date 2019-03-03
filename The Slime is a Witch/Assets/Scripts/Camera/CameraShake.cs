using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float _duration, float _magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float timeElapsed = 0.0f;

        while (timeElapsed < _duration)
        {
            float x = Random.Range(-1.0f, 1.0f) * _magnitude;
            float y = Random.Range(-1.0f, 1.0f) * _magnitude;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    public void StartShake(float _shakeDuration, float _shakeMagnitude)
    {
        StartCoroutine(Shake(_shakeDuration, _shakeMagnitude));
    }
}
