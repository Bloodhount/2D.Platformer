using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public float dumping = 2.5f;
    public Vector2 offset = new Vector2(1.5f, 1f);
    public bool isLeft;
    [SerializeField] private Transform _player;
    private int lastX;

    
    void Start()
    {
        float scale = transform.position.x;

        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
     
    }

    public void FindPlayer(bool playerIsLeft)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;// 
        lastX = Mathf.RoundToInt(_player.position.x);
       
        if (playerIsLeft)
        {
            transform.position = new Vector3(_player.position.x - offset.x, _player.position.y - offset.y, transform.position.z);
           
        }
        else
        {
            transform.position = new Vector3(_player.position.x + offset.x, _player.position.y + offset.y, transform.position.z);

        }
    }

    //private void FindPlayer(bool isLeft)
    //{
    //    throw new NotImplementedException();
    //}


    void Update()
    {
        if (_player)
        {
            int currentX = Mathf.RoundToInt(_player.position.x);
            if (currentX> lastX) isLeft = false; else if (currentX < lastX) isLeft = true;

            lastX = Mathf.RoundToInt(_player.position.x);

            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(_player.position.x - offset.x, _player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(_player.position.x + offset.x, _player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
