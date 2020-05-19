using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Start()
    {
        InvokeRepeating("Shoot",0.1f,0.5f);
    }
    
    void Shoot()
    {       
        nextFire = Time.time + fireRate;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        shot.tag = GameSetting.EnemyBulletTag;        
    }
}
