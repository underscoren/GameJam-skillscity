using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    void Update() {
        var pos = transform.position;
        pos -= new Vector3(0,_speed * Time.deltaTime,0);
        transform.position = pos;

        if (pos.y < -10)
            Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Destroy(other);
        }
    }
}
