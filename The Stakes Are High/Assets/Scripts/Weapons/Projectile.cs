using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public Transform shootLocation;
    public float projectileSpeed = 10f;
    public float timeBeforeDestroy = 7f;

    private void Update()
    {
        ShootForward(shootLocation.right);

        Destroy(gameObject, timeBeforeDestroy);
    }

    protected void ShootForward(Vector3 _direction)
    {
        gameObject.transform.Translate(_direction * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
