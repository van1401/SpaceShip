using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using Core.Pool;

public class EnemyController : SpaceShipController
{
    public float _enemyHp;
    public BulletController [] bullet;
    public float speed;
    public EffectController HitEffect;



    public void CreateHitEffect()
    {
        SmartPool.Instance.Spawn(HitEffect.gameObject, this.transform.position, this.transform.rotation);
    }
    void Update()
    {
        Terminate();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            _enemyHp = bullet[0].calculateHP(_enemyHp);
            CreateHitEffect();
        }
        if (collision.transform.gameObject.CompareTag("PlayerBullet"))
        {
            _enemyHp = bullet[0].calculateHP(_enemyHp);
        }
        if (collision.transform.gameObject.CompareTag("Shield"))
        {
            _enemyHp = bullet[0].calculateHP(_enemyHp);
            CreateHitEffect();
        }
    }

    public virtual void calculateHP(float damage)
    {
        _enemyHp -= damage; 
    }

    public void initData()
    {
        _enemyHp = Hp;
    }
    public override void Terminate()
    {
        if (_enemyHp <= 0)
        {
            this.PostEvent(EventID.EnemyDie);
            Destroy(bodySpaceShip.gameObject);
            CreateEffect();
        }
    }
}
