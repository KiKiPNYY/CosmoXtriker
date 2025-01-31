﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private float followRange = 500f;
   
    [SerializeField]
    private float attackrange = 100f;
    private PlayerController player;
    private bool startbattle;
    // Start is called before the first frame update
    void Start()
    {
        startbattle = false;
        //プレーヤーを探す機能
        player = FindObjectOfType<PlayerController>();   
    }

    // Update is called once per frame
    void Update()
    {
        //プレーヤーと敵の距離
        var distanceToPlayer = (this.transform.position-player.transform.position).sqrMagnitude;

        if (!startbattle)
        {
            //レンジを作って、その中でエネミーはプレーヤの場へ向かう
            if (distanceToPlayer <= followRange )
            {

                this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.2f);
            }
            else
            {
                this.transform.Translate(0, 0, -0.2f, Space.World);
            }

            if (distanceToPlayer <= attackrange)
            {
                startbattle = true;
            }
        }
       
        else
        {　　　//真っ直ぐへ移動
            this.transform.Translate(0, 0, -0.2f,Space.World);
        }
    }
}
