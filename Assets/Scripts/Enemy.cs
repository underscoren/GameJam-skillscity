using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    private GameManager gm;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        var pos = transform.position;
        pos -= new Vector3(0,_speed * Time.deltaTime,0);
        transform.position = pos;

        if (pos.y < -10)
            Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision");
        if(other.gameObject.CompareTag("Player")) {
            Destroy(other.gameObject);
            gm.GameOver();
        }
    }
}
