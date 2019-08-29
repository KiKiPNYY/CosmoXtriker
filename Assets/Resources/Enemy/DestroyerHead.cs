﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerHead :_tmpEnemys
{
    [SerializeField] float chageAttackTimer = 10f;
    [SerializeField]
    float changeAttackCounte;
    [SerializeField] float fireRate = 2f;
    public static DestroyerHead instance;
    [SerializeField]
    bomberMissile missiles;
    [SerializeField]
    Transform[] missileSpawnPoints;
    [SerializeField]
    DestroyerCannonAttack[] cannons;
    int currentAttack;
    float fireCounter;
    

    public enum attackType { bullet,missile}
    public attackType Type;

    private void Awake()
    {
        instance = this;
        Type = attackType.bullet;
    }

    private void Start()
    {
        fireCounter = fireRate;
        cannons = FindObjectsOfType<DestroyerCannonAttack>();
    }
    private void Update()
    {
        changeAttackCounte -= Time.deltaTime;
        if (changeAttackCounte <= 0)
        {
            changeAttackCounte = chageAttackTimer;
            switch (Type)
            {
                case attackType.bullet:Type = attackType.missile; break;
                case attackType.missile:Type = attackType.bullet; break;
            }
        }
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = fireRate;
            if (Type==attackType.bullet)
            {
                for (int i=0;i<cannons.Length;i++)
                {
                    if (currentAttack > cannons.Length) currentAttack = 0;
                    if (cannons[currentAttack] != null)
                    {
                        cannons[currentAttack].fire();
                        currentAttack++;
                        if (currentAttack >= cannons.Length) { currentAttack = 0; }
                        break;
                    }
                }
            }
            else
            {
                if (currentAttack > missileSpawnPoints.Length) { currentAttack = 0; }

                Instantiate(missiles, missileSpawnPoints[currentAttack].position, missileSpawnPoints[currentAttack].rotation);
                currentAttack++;
                if (currentAttack >= missileSpawnPoints.Length) { currentAttack = 0; }

            }
        }
        
    }

}
