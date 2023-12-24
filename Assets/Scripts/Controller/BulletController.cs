using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
using LTAUnityBase.Base.DesignPattern;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float time = 0;
    public float damage;
    public EffectController HitEffect;
    public BulletController[] bullet;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        destroyBullet();
    }


    public virtual void destroyBullet()
    {
        if (time == 230)
        {
            SmartPool.Instance.Despawn(bullet[0].gameObject);
            resetTime();
        }
        time++;
        this.transform.position += transform.up * Time.deltaTime * speed;
    }
    public virtual void resetTime()
    {
        for (int i = 0; i < time; i++)
        {
            if (time == 230)
            {
                time = 0;
            }
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {   

    }

    public virtual float calculateHP(float hp)
    {
        var hpLeft = hp - damage;
        return hpLeft;
    }
    public virtual void CreateHitEffect()
    {
         SmartPool.Instance.Spawn(HitEffect.gameObject, this.transform.position, this.transform.rotation);
    }
}

