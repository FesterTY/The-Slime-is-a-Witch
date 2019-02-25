using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HealthManager))]
public class Destructible : MonoBehaviour
{
    public int damageAmount = 1;
    public float flashTime = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            gameObject.GetComponent<HealthManager>().Harm(damageAmount);
            StartCoroutine(ObjectFlash());
        }
    }

    protected IEnumerator ObjectFlash()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        yield return new WaitForSeconds(flashTime);
        renderer.enabled = true;
    }
}
