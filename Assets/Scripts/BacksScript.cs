using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Material;

public class BacksScript : MonoBehaviour
{



    Vector2 offset = Vector2.zero;

    //// Start is called before the first frame update
    void Start()
    {

    }

    float speedBacks ;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * 
                Time.deltaTime /* * speedBacks*/ , 0f ));
        }
    }
}
