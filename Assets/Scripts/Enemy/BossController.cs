using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class BossController : EnemyController
{
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    bool once;
    public Transform[] transhoot;
    private SoundController audioManager;
    void Start()
    {

    }
    private void OnEnable()
    {
        initData();
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != patrolPoints[currentPointIndex].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
        Terminate();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            _enemyHp = bullet[0].calculateHP(_enemyHp);
            _enemyHp = bullet[1].calculateHP(_enemyHp);
            _enemyHp = bullet[2].calculateHP(_enemyHp);
            CreateHitEffect();
        }
        if (collision.transform.gameObject.CompareTag("PlayerBullet"))
        {
            _enemyHp = bullet[0].calculateHP(_enemyHp);
            _enemyHp = bullet[1].calculateHP(_enemyHp);
            _enemyHp = bullet[2].calculateHP(_enemyHp);
        }
        if (collision.transform.gameObject.CompareTag("Shield"))
        {
            _enemyHp = bullet[0].calculateHP(_enemyHp);
            _enemyHp = bullet[1].calculateHP(_enemyHp);
            _enemyHp = bullet[2].calculateHP(_enemyHp);
            CreateHitEffect();
        }

    }
    public override void Terminate()
    {
        if (_enemyHp <= 0)
        {
            audioManager.PlaySFX(audioManager.bossExplosion);
            this.PostEvent(EventID.BossDie);
            SmartPool.Instance.Despawn(bodySpaceShip.gameObject);
            CreateEffect();
        }
    }

    public IEnumerator Shoot()
    {
        var size1 = new Vector3(0.2f, 0.7f, 1);
        var size2 = new Vector3(0.4f, 0.4f, 1);

        while (true)
        {
            if (this.gameObject.transform.position.y <= 10)
            {

                if (_enemyHp >= 20000 && _enemyHp <= 30000)
                {                   
                  var scaleDown =  SmartPool.Instance.Spawn(bullet[0].gameObject, transhoot[0].transform.position, transhoot[0].transform.rotation);
                  var scaleDown1 = SmartPool.Instance.Spawn(bullet[0].gameObject, transhoot[1].transform.position, transhoot[1].transform.rotation);
                  scaleDown.transform.localScale = size1;
                  scaleDown1.transform.localScale = size1;
                   
                }
            }
            if (_enemyHp >=8000 && _enemyHp <= 20000)
            {
                if (this.gameObject.transform.position == patrolPoints[0].transform.position)
                {
                    var scaleDown = SmartPool.Instance.Spawn(bullet[2].gameObject, transhoot[2].transform.position, transhoot[2].transform.rotation = Quaternion.Euler(0,0,-180));
                    scaleDown.transform.localScale = size2;
                }
                if (this.gameObject.transform.position == patrolPoints[1].transform.position)
                {
                    var scaleDown = SmartPool.Instance.Spawn(bullet[2].gameObject, transhoot[2].transform.position, transhoot[2].transform.rotation = Quaternion.Euler(0, 0, -190));
                    scaleDown.transform.localScale = size2;
                }
                if (this.gameObject.transform.position == patrolPoints[2].transform.position)
                {
                    var scaleDown = SmartPool.Instance.Spawn(bullet[2].gameObject, transhoot[2].transform.position, transhoot[2].transform.rotation = Quaternion.Euler(0, 0, 190));
                    scaleDown.transform.localScale = size2;
                }
            }

            if (_enemyHp < 8000)
            {
                var scaleDown = SmartPool.Instance.Spawn(bullet[0].gameObject, transhoot[2].transform.position, transform.rotation);
                var scaleDown1 = SmartPool.Instance.Spawn(bullet[2].gameObject, transhoot[3].transform.position, transhoot[3].transform.rotation);
                var scaleDown2 =  SmartPool.Instance.Spawn(bullet[2].gameObject, transhoot[4].transform.position, transhoot[4].transform.rotation);
                scaleDown.transform.localScale = size2;
                scaleDown1.transform.localScale = size2;
                scaleDown2.transform.localScale = size2;

            }
            yield return new WaitForSeconds(delayShoot);
         }
    }
}
