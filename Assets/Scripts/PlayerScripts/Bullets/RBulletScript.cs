using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBulletScript : MonoBehaviour
{
    [SerializeField] private float _speedR = 2;
    [SerializeField] private float _lifeTimeR = 3;
    [SerializeField] private int _damageR = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTimeR);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += CalcSpeedR(_speedR);
    }

    private Vector3 CalcSpeedR(float dir)
    {
        return transform.right * Time.deltaTime * dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<MyEnemy>();
            enemy.Hurt(_damageR);
        }

        if (!collision.gameObject.CompareTag("Player")) Destroy(gameObject);
        {

        }
    }

}
