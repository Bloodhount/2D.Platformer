﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Material;

public class BacksParalaxScript : MonoBehaviour
{
    Transform target;

    Material material;

    [SerializeField] float scale = 3.0f;

    Vector2 offset = Vector2.zero;

    //// Start is called before the first frame update
    void Start()
    {
        target = transform.root;
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(target.position.x/100f/scale, 0f);
        material.mainTextureOffset = offset;


    }
}
