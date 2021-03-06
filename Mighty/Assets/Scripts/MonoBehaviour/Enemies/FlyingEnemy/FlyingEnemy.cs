﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy,IDamageable{


    public int Health { get; set; }

    public Transform[] waypoints;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;


    [SerializeField]
    private GameObject bloodEffectPrefab;


    [SerializeField]
    private GameObject deathEffectPrefab;

    [SerializeField]
    private float maxDistance;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Start()
    {
        base.Start();
        randomSpot = Random.Range(0, waypoints.Length);
        waitTime = startWaitTime;
    }
    //Prendre des dégats
    public void TakeDamage(int damageAmount)
    {
        //Debug.Log("Damage Taken");
         Health = Health - damageAmount;
        GameObject effect = Instantiate(bloodEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 0.5f);
        //Debug.Log("is Hit is true now");
        //anim.SetTrigger("HURT");

        if (Health <= 0)
        {
            camRipple.RippleEffect();
            FindObjectOfType<AudioManager>().Play("FlyingEnemyDeath");
            GameObject effectD = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
            Destroy(effectD, 2.5f);
            
            SpawnGems();
            Destroy(this.gameObject, 0.3f);

        }
    }

    public override void Update()
    {
      distance = Vector3.Distance(transform.position, player.transform.position);
      if(distance > maxDistance)
      {
            Movement();
      }
      else{
            Chase();
      }
    }
    public override void Movement()
    {
        anim.SetBool("Done", true);
        transform.position = Vector2.MoveTowards(transform.position, waypoints[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, waypoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    public override void Chase()
    {
        anim.SetBool("Done", false);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}