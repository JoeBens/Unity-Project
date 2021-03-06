﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    [SerializeField]
    private Sprite activatedState;

    public bool activated = false;

    private SpriteRenderer spriteRenderer;

    public GameObject effectActivation;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(( collision.gameObject.tag=="FireBall" || collision.gameObject.tag == "PlayerHitbox" ) && activated == false)
        {
            spriteRenderer.sprite = activatedState;
            FindObjectOfType<AudioManager>().Play("SwitchActivated");
            GameObject effectD = Instantiate(effectActivation, transform.position, transform.rotation);
            Destroy(effectD, 2.5f);
            activated = true;
        }
    }

 
}
