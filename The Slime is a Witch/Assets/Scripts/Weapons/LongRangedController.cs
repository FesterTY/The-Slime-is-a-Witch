using UnityEngine;

public class LongRangedController : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootLocation;

    public float timeBetweenShots = 0.35f;
    float timeBetweenShotsCounter;

    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;

    public void Shoot(string inputAxis)
    {
        timeBetweenShotsCounter -= Time.deltaTime;
        if (Input.GetAxisRaw(inputAxis) > 0 && timeBetweenShotsCounter < 0)
        {
            Instantiate(projectile, shootLocation.position, transform.rotation);
            timeBetweenShotsCounter = timeBetweenShots;
        }
    }
}
