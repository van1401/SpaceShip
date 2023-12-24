using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool; 

public class EnemyBulletController : BulletController
{
    private void Update()
    {
        destroyBullet();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            SmartPool.Instance.Despawn(bullet[0].gameObject);
            CreateHitEffect();
        }
        if (collision.transform.tag == "Shield")
        {
            SmartPool.Instance.Despawn(bullet[0].gameObject);
        }
    }
    public override void resetTime()
    {
        for (int i = 0; i < time; i++)
        {
            if (time == 350)
            {
                time = 0;
            }
        }
    }
    public override void destroyBullet()
    {
        if (time == 350)
        {
            SmartPool.Instance.Despawn(bullet[0].gameObject);
            resetTime();
        }
        time++;
        this.transform.position += transform.up * Time.deltaTime * speed;
    }
}
