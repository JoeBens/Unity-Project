﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    Rigidbody2D rb;
    // Use this for initialization
    public float fallMulti;
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }
    // Update is called once per frame
    void Update () {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
            
    }
   
                    
}
