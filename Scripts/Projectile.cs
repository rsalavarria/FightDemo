using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 30;
    public GameObject impactVFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity += transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var impact = Instantiate(impactVFX, transform.position, Quaternion.identity);
        Destroy(impact, 2);
        Destroy(gameObject);
    }
}
