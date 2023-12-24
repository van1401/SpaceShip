using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class PlayerBulletController : BulletController
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            SmartPool.Instance.Despawn(bullet[0].gameObject);
            CreateHitEffect();
        }
        if (collision.transform.tag == "Boss")
        {
            SmartPool.Instance.Despawn(bullet[0].gameObject);
            CreateHitEffect();
        }
    }

}
