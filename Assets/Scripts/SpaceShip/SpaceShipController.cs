using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
using LTAUnityBase.Base.DesignPattern;

public class SpaceShipController : MoveController
{
    public static SpaceShipController Instance;
    public float Hp;
    public float delayShoot;
    public float delayShoot1;

    public Transform bodySpaceShip;
    public EffectController destructionVFX;


    public virtual void Terminate()
    {
        if (Hp <= 0)
        {
            this.PostEvent(EventID.EnemyDie); 
            SmartPool.Instance.Despawn(bodySpaceShip.gameObject);
            CreateEffect();
        }   
    }
    public virtual void CreateEffect()
    {
       SmartPool.Instance.Spawn(destructionVFX.gameObject, this.transform.position, this.transform.rotation);
    }
}
