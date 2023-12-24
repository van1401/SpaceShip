using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;


public class CreepEnemyController : EnemyController
{
    public Transform transhoot;
    [Range(0,100)]
    public int shootChance;
    
    private void OnEnable()
    {
        initData();
        StartCoroutine(Shoot());
    }


    // Update is called once per frame
    void Update()
    {
        Move(transform.up);
        Terminate();
    }
    public IEnumerator Shoot()
    {
        while (true)
        {
            if (this.gameObject.transform.position.y < 10)
            {
                if (Random.value < (float)shootChance / 100)
                {
                    var scaleDown = SmartPool.Instance.Spawn(bullet[0].gameObject, transhoot.transform.position, transhoot.transform.rotation);
                    scaleDown.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }
            }
            yield return new WaitForSeconds(delayShoot);
        }
    }

    void Move(Vector3 direction)
    {
        this.gameObject.transform.position += direction * Time.deltaTime * speed;
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
