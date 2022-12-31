using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public string enemyTag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == enemyTag)
            other.GetComponent<Health>().TakeDamage(damage);
    }
}
