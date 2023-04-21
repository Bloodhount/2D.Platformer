using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCharacter : MonoBehaviour
{
    public Animator PlAnim;
    public Rigidbody2D PlRb;
    public Vector2 moveVector;
    
    public static bool GameIsPaused = false;

    private string _currentAnimState;

    [SerializeField] public float _playerSpeed = 2;
    [SerializeField] private int _healthPlayer = 2;
    [SerializeField] private int _healthPlayerMax = 10;
    [SerializeField] private GameObject _bulletR;//
    [SerializeField] private GameObject _bulletL;//
    [SerializeField] private Transform _startBulletR;//
    [SerializeField] private Transform _startBulletL;//
    [SerializeField] private GameObject ObjHealthBarUI;//

    const string PLAYER_IDLE    = "PlayerIdle";
    const string PLAYER_WALK_L  = "PlayerWalkL";
    const string PLAYER_WALK_R  = "PlayerWalkR";
    const string PLAYER_JUMP    = "Idle Jump Player Animation";
    const string PLAYER_JUMP_L  = "Jump Player AnimationL";
    const string PLAYER_JUMP_R  = "Jump Player AnimationR";
    const string PLAYER_DOUBLE_JUMP_L  = " ";
    const string PLAYER_DOUBLE_JUMP_R  = "doubleJumpR";

    void Start()
    {
        PlRb = GetComponent<Rigidbody2D>();
        PlAnim = GetComponent<Animator>();
       // PlAnim.Play(PLAYER_IDLE);
        //_stay = new Vector2Int(0, 0);
        print(UnityEngine.Random.insideUnitSphere);
        ObjHealthBarUI.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space) && plOnGrnd)
        {
            print("PLAYER_JUMP!");
            ChangeAnimationState(PLAYER_JUMP);
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (_currentAnimState == newState) return;
        PlAnim.Play(newState);
        _currentAnimState = newState;
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    void Update()
    {
        Fire();
    }

    public void Hurt(int damage)
    {
        _healthPlayer -= damage;

        var sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.yellow;

        if (_healthPlayer <= 0)
        {
            Die();
        }
    }

    public void Healing(int damage)
    {
        _healthPlayer += damage;

        var sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.green;

        //if (_healthPlayer <= _healthPlayerMax)
        //{
        //    _healthPlayer += damage;
        //}
    }

    private void Die()
    {
        Destroy(gameObject);
        //throw new NotImplementedException();
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1") && moveVector.x > 0)
        {
            print("fire R");
            Instantiate(_bulletR, _startBulletR.position, _startBulletR.rotation);
        }

        if (Input.GetButtonDown("Fire1") && moveVector.x  < 0)
        {
            print("fire L");
            Instantiate(_bulletL, _startBulletL.position, _startBulletL.rotation);
        }
    }

    //void WalkL()
    //{
    //    moveVector.x = Input.GetAxis("Horizontal");
    //    PlRb.velocity = new Vector2(moveVector.x * _playerSpeed, PlRb.velocity.y);
    //}

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        PlAnim.SetFloat("moveVector.x", moveVector.x);
        PlRb.velocity = new Vector2(moveVector.x * _playerSpeed, PlRb.velocity.y);
        if (moveVector.x < 0)
        {
            ChangeAnimationState(PLAYER_WALK_L);
        }
        else if (moveVector.x > 0)
        {
            ChangeAnimationState(PLAYER_WALK_R);
        }
        else
        {
            PlAnim.Play(PLAYER_IDLE);
        }
    }

    public float _jumpForce = 7f;
    public float _jumpTime = 0;
    public float _jumpControlTime = 0.7f;
    public float _doubleJumpVelocity = 10f;
    private int _jumpCount = 0;
    public int _maxJumpValue = 2;
    public bool _jumpControl;

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //ChangeAnimationState(PLAYER_JUMP);
            if (plOnGrnd)
            {
               // PlAnim.StopPlayback();
               // PlAnim.Play("Jump");
                _jumpControl = true;
                print("jump");
            }
        }
        else
        {
            _jumpControl = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !plOnGrnd && (++_jumpCount < _maxJumpValue))
        {
           // PlAnim.StopPlayback();
           // PlAnim.Play("doubleJump");
            PlRb.velocity = new Vector2(0, _doubleJumpVelocity);
            print("doubleJump");
        }

        if (plOnGrnd)
        {
            _jumpCount = 0;
        }

        if (_jumpControl)
        {
            if ((_jumpTime += Time.deltaTime) < _jumpControlTime)
            {
                PlRb.AddForce(Vector2.up * _jumpForce / (_jumpTime * 10));
            }
        }
        else
        {
            _jumpTime = 0;
        }

        CheckingGround();

        //if (Input.GetKeyDown(KeyCode.Space) && !plOnGrnd && moveVector.x < 0)
        //{
        //    ChangeAnimationState(PLAYER_JUMP_L);
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && !plOnGrnd && moveVector.x > 0)
        //{
        //    ChangeAnimationState(PLAYER_DOUBLE_JUMP_R);
        //}
        //else ChangeAnimationState(PLAYER_JUMP);

        //if (Input.GetKeyDown(KeyCode.Space) && !plOnGrnd)
        //{
        //    print("checked!");
        //    ChangeAnimationState(PLAYER_JUMP);
        //}
    }

    public bool plOnGrnd;
    public Transform CheckGrnd;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    void CheckingGround()
    {
        plOnGrnd = Physics2D.OverlapCircle(CheckGrnd.position, checkRadius, Ground);
        PlAnim.SetBool("plOnGrnd", plOnGrnd);

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Hurt(1); 
                     // SceneManager.LoadScene(1);
                     //SceneManager.LoadScene("MainMenu");
                     //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (col.tag == "Fire")
        {
            print("BOOM !");
            SceneManager.LoadScene(1);
            //SceneManager.LoadScene("MainMenu");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
