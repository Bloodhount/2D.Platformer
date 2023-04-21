using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBulletScript : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private int _damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= CalcSpeed(_speed);

    }

    private Vector3 CalcSpeed(float dir)
    {
        return transform.right * Time.deltaTime * dir;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
        }

        if (!collision.gameObject.CompareTag("Player")) Destroy(gameObject);
        {

        }
    }
}
