using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAgrToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float seeDist = 2f;

    private Vector2 _startEnemyPos;
    private Rigidbody2D _enemyRig;
    private Transform Target;
    //public bool CollisionFlags ;
    //private Vector2 _enemyVector;
    //public Quaternion startPos;

    private void Start()
    {
        _enemyRig = GetComponent<Rigidbody2D>();
        Target = GameObject.FindWithTag("Player").transform;
      /*  if (Vector2.Distance(transform.position, Target.transform.position) < seeDist)
        {
            MoveToPlayer();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _startEnemyPos, _enemySpeed * Time.deltaTime);

        }*/

    }

    private void Update()
    {
          if (Vector2.Distance(transform.position, Target.transform.position) < seeDist)
          {
              MoveToPlayer();
          }
          else
          {
              transform.position = Vector2.MoveTowards(transform.position, _startEnemyPos,_enemySpeed * Time.deltaTime);

          }
    }

    private void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, _enemySpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //transform.LookAt(Target);
            // transform.position = Vector2.MoveTowards(transform.position, Target.position, Time.deltaTime);
            MoveToPlayer();
            //CollisionFlags == true;
        }
    }


}
