﻿using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public Transform shootLocation;
    public float projectileSpeed = 10f;
    public float timeBeforeDestroy = 7f;

    AudioSource impactEffect;
    AudioManager audioManager;
    
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        
        if (audioManager != null)
        {
            impactEffect = GameObject.Find("ImpactEffect").GetComponent<AudioSource>();
        }
    }

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
        if (!collision.GetComponent<Carrot>())
        {
            audioManager.PlayEffect(impactEffect);
            Destroy(gameObject);
        }
    }
}
