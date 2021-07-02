using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private IEnumerator projectileCoroutine;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void DeactivateProjectile(float lifetime)
    {
        if (projectileCoroutine != null)
        {
            StopCoroutine(projectileCoroutine);
        }

        projectileCoroutine = DeactivateInTime(lifetime);
        StartCoroutine(projectileCoroutine);
    }

    IEnumerator DeactivateInTime(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Enemy.ToString()))
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
}
