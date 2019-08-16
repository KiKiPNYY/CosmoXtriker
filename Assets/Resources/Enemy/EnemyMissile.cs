﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    [SerializeField] float velocity = 4f;
    [SerializeField] float lifetime = 5f;
    [SerializeField] int damage = 10;
    [SerializeField]
    float veloctyTimeFactor = 100f;
    System.Action _callback = null;
    bool followPlayer;
    Vector3 newTarget;

    private void Start()
    {
        followPlayer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            if (PlayerController.instance != null)
            {
                //プレイヤーへ動く
                transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, velocity*(Time.deltaTime*veloctyTimeFactor));
            }
        }
        else
        {
            //flayrのため
        
            transform.position = Vector3.MoveTowards(transform.position, newTarget, velocity * (Time.deltaTime * veloctyTimeFactor));
        }
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            //時間が経ったら爆発する、callbackで敵シップにメッセージを送る
            if (_callback != null)
                _callback();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    //callback
    public void Init(System.Action callback)
    {
        _callback = callback;
    }

    //削除
    private void OnTriggerEnter(Collider other)
    {
        if (_callback != null)
            _callback();
        if (other.tag == "Player"|| other.name == "KillZone")
        {
            other.GetComponent<HealthManager>().Takedamage(damage);
            
            if (other.tag == "Player")
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
       

    }
    //新しいtargetを作る
    public void giveATarget(Vector3 pos)
    {

        newTarget = pos;
        followPlayer = false;
    }
        
}
  
