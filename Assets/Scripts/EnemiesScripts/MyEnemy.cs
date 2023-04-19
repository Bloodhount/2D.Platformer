using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _healthEnemy;
    [SerializeField] private GameObject _pickUp;

    public Animator animatorEnemy;

    private string currState;
    private string newState;
    const string ENEMY_IDLE = "EnemyIdle";
    const string ENEMY_LWALK = "EnemyWalkL";
    const string ENEMY_RWALK = "EnemyWalkR";

    public void Hurt(int damage)
    {
        _healthEnemy -= damage;

        var sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.red;

        if (_healthEnemy <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(_pickUp, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void ChangeAnimatioState(string currState)
    {
        if (currState == newState) 
        {
            return;
        }

        animatorEnemy.Play(newState);

        currState = newState;
    }

    // Start is called before the first frame update
    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        animatorEnemy.Play("EnemyWalkL");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
