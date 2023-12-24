using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Pool;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : SpaceShipController
{
    public int level;
    public float totalHP;
    public Slider slider_HP;
    public GameObject hpPoint;
    public Slider slider_EXP;
    public GameObject expPoint;
    public float currentExp, targetExp;
    public GameObject Shield;
    public Transform[] transhoot;
    public float bulletLevel;
    public float winglevel;
    public BulletController[] bullet;
    public EffectController heallingEffect;
    public EffectController upgradegunEffect;
    public EffectController shieldEffect;
    public EffectController [] shootEffect;
    private SoundController audioManager;
    public GameObject WingUpgrade;

    void Start()
    {
        bulletLevel = 1;
        winglevel = 0;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


        slider_HP.maxValue = Hp;
        slider_EXP.maxValue = targetExp;
        this.RegisterListener(EventID.EnemyDie, (sender, param) =>
       {
           currentExp += 1;
       });

        audioManager = GameObject.FindGameObjectWithTag("GameMusic").GetComponent<SoundController>();
    }

    private void OnEnable()
    {
            StartCoroutine(Shoot());
            StartCoroutine(WingShoot());
    }
    void Update()
    {
        calculateEXP();
        HPBarStatus();
        Terminate();
    }

    public virtual IEnumerator Shoot()
    {
        while (true)
        {
            if (bulletLevel == 1)
            {
                ///Create Sound
                audioManager.PlaySFX(audioManager.shooting);
                ///Create Effect
                SmartPool.Instance.Spawn(shootEffect[0].gameObject, transhoot[0].transform.position, Quaternion.identity);
                ///Shoot
                SmartPool.Instance.Spawn(bullet[0].gameObject, transhoot[0].transform.position, transhoot[0].transform.rotation);
            }
            if (bulletLevel == 2)
            {
                ///Create Sound
                audioManager.PlaySFX(audioManager.shooting);
                ///Create Effect
                SmartPool.Instance.Spawn(shootEffect[1].gameObject, transhoot[1].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[1].gameObject, transhoot[2].transform.position, Quaternion.identity);
                ///Shoot
                SmartPool.Instance.Spawn(bullet[1].gameObject, transhoot[1].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(bullet[1].gameObject, transhoot[2].transform.position, Quaternion.identity);
            }
            if (bulletLevel == 3)
            {
                ///Create Sound
                audioManager.PlaySFX(audioManager.shooting);
                ///Create Effect
                SmartPool.Instance.Spawn(shootEffect[2].gameObject, transhoot[0].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[2].gameObject, transhoot[1].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[2].gameObject, transhoot[2].transform.position, Quaternion.identity);
                ///Shoot
                SmartPool.Instance.Spawn(bullet[2].gameObject, transhoot[0].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(bullet[2].gameObject, transhoot[1].transform.position, transhoot[1].transform.rotation = Quaternion.Euler(0, 0, 5));
                SmartPool.Instance.Spawn(bullet[2].gameObject, transhoot[2].transform.position, transhoot[2].transform.rotation = Quaternion.Euler(0, 0, -5));
            }
            if (bulletLevel == 4)
            {
                ///Create Sound
                audioManager.PlaySFX(audioManager.shooting);
                ///Create Effect
                SmartPool.Instance.Spawn(shootEffect[3].gameObject, transhoot[0].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[3].gameObject, transhoot[1].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[3].gameObject, transhoot[2].transform.position, Quaternion.identity);
                ///Shoot, using Euler to calculate the rotation
                SmartPool.Instance.Spawn(bullet[3].gameObject, transhoot[0].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(bullet[3].gameObject, transhoot[1].transform.position, transhoot[1].transform.rotation = Quaternion.Euler(0, 0, 5));
                SmartPool.Instance.Spawn(bullet[3].gameObject, transhoot[2].transform.position, transhoot[2].transform.rotation = Quaternion.Euler(0, 0, -5));
                SmartPool.Instance.Spawn(bullet[3].gameObject, transhoot[1].transform.position, transhoot[1].transform.rotation = Quaternion.Euler(0, 0, 15));
                SmartPool.Instance.Spawn(bullet[3].gameObject, transhoot[2].transform.position, transhoot[2].transform.rotation = Quaternion.Euler(0, 0, -15));
            }
            yield return new WaitForSeconds(delayShoot);
        }
    }

    public IEnumerator WingShoot()
    {
        var  size = new Vector3(0.8f, 0.8f, 0.8f);
        while (true)
        {
           
            if (winglevel == 1)
            {
                ///Create Sound
                audioManager.PlaySFX(audioManager.shooting);
                ///Create Effect
                SmartPool.Instance.Spawn(shootEffect[4].gameObject, transhoot[3].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[4].gameObject, transhoot[4].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[4].gameObject, transhoot[5].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[4].gameObject, transhoot[6].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[4].gameObject, transhoot[7].transform.position, Quaternion.identity);
                SmartPool.Instance.Spawn(shootEffect[4].gameObject, transhoot[8].transform.position, Quaternion.identity);
                ///Shoot, using Euler to calculate the rotation
                var scaleDown = SmartPool.Instance.Spawn(bullet[4].gameObject, transhoot[3].transform.position, Quaternion.identity);
                var scaleDown1 = SmartPool.Instance.Spawn(bullet[4].gameObject, transhoot[4].transform.position, Quaternion.identity);
                var scaleDown2 = SmartPool.Instance.Spawn(bullet[4].gameObject, transhoot[5].transform.position, Quaternion.identity);
                var scaleDown3 = SmartPool.Instance.Spawn(bullet[4].gameObject, transhoot[6].transform.position, Quaternion.identity);
                var scaleDown4 = SmartPool.Instance.Spawn(bullet[4].gameObject, transhoot[7].transform.position, Quaternion.identity);
                var scaleDown5 = SmartPool.Instance.Spawn(bullet[4].gameObject, transhoot[8].transform.position, Quaternion.identity);
                scaleDown.transform.localScale = size;
                scaleDown1.transform.localScale = size;
                scaleDown2.transform.localScale = size;
                scaleDown3.transform.localScale = size;
                scaleDown4.transform.localScale = size;
                scaleDown5.transform.localScale = size;

            }
            yield return new WaitForSeconds(delayShoot1);
        }
    }

    public override void Terminate()
    {
        if (Hp <= 0)
        {
            audioManager.PlaySFX(audioManager.death);
            this.PostEvent(EventID.EnemyDie);
            SmartPool.Instance.Despawn(bodySpaceShip.gameObject);
            CreateEffect();
        }
    }

    private void calculateEXP()
    {
        if (currentExp >= targetExp)
        {
            currentExp -= targetExp;
            audioManager.PlaySFX(audioManager.levelup);
            level++;
            this.PostEvent(EventID.LevelUp);

        }
        slider_EXP.value = currentExp;
    }

    private void HPBarStatus()
    {
        slider_HP.value = Hp;
        if (Hp <= 0)
        {
            hpPoint.gameObject.SetActive(false);
        }
        else
        {
            hpPoint.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.transform.gameObject.CompareTag("Enemy"))
        {
            Hp = bullet[0].calculateHP(Hp);
            if(Hp <= 0)
            {
                GameController.Instance.YouLose();
            }
        }
        if (collision.transform.gameObject.CompareTag("Boss"))
        {
            Hp = bullet[0].calculateHP(Hp);
            if (Hp <= 0)
            {
                GameController.Instance.YouLose();
            }
        }
        if (collision.transform.gameObject.CompareTag("EnemyBullet"))
        {
            Hp = bullet[0].calculateHP(Hp);
            if (Hp <= 0)
            {
                GameController.Instance.YouLose();
            }
        }
        if (collision.transform.gameObject.CompareTag("FrostEnemyBullet"))
        {
            Hp = bullet[0].calculateHP(Hp);
            delayShoot = 0.7f;
            delayShoot1 = 1f;
            LeanTween.delayedCall(3f, () =>
            {
                delayShoot = 0.3f;
                delayShoot1 = 0.6f;
            });
            if (Hp <= 0)
            {
                GameController.Instance.YouLose();
            }
        }
        if (collision.transform.gameObject.CompareTag("BossBullet"))
        {
            Hp = bullet[0].calculateHP(Hp);
            if (Hp <= 0)
            {
                GameController.Instance.YouLose();
            }
        }
        if (collision.transform.gameObject.CompareTag ("HealthPotion"))
        {
            audioManager.PlaySFX(audioManager.healthPickUp);
            var scaleUp = SmartPool.Instance.Spawn(heallingEffect.gameObject, transform.position, Quaternion.identity);
            scaleUp.transform.localScale = new Vector3(2, 2, 2);
            if(Hp < 1000)
            {
                Hp += Random.Range(30, 50);
                if (Hp >= 1000)
                {
                    Hp = 1000;
                }
            }
            //SmartPool.Instance.Despawn(collision.transform.gameObject);
            Destroy(collision.transform.gameObject);
        }
        if (collision.transform.gameObject.CompareTag("ShieldPotion"))
        {
            Shield.SetActive(true);
            audioManager.PlaySFX(audioManager.shield);
            var scaleUp = SmartPool.Instance.Spawn(shieldEffect.gameObject, transform.position, Quaternion.identity);
            scaleUp.transform.localScale = new Vector3(2, 2, 2);
            //SmartPool.Instance.Despawn(collision.transform.gameObject);
            Destroy(collision.transform.gameObject);
            LeanTween.delayedCall(10f, () =>
            {
                Shield.SetActive(false);
            });
        }
         if (collision.transform.gameObject.CompareTag("UpgradePotion"))
        {
            audioManager.PlaySFX(audioManager.upgradeItem);
            var scaleUp = SmartPool.Instance.Spawn(upgradegunEffect.gameObject, transform.position, Quaternion.identity);
            scaleUp.transform.localScale = new Vector3(2, 2, 2);
            bulletLevel += 1;               
            //SmartPool.Instance.Despawn(collision.transform.gameObject);
            Destroy(collision.transform.gameObject);
            if (bulletLevel == 2)
            {
                LeanTween.delayedCall(30f, () =>
                {
                    bulletLevel = 1;
                });
            }

            if (bulletLevel == 3)
            {
                LeanTween.delayedCall(30f, () =>
                {
                    bulletLevel = 1;
                });
            }

            if (bulletLevel == 4)
            {
                LeanTween.delayedCall(30f, () =>
                {
                    bulletLevel = 1;
                });
            } 
            if (bulletLevel >= 4)
            {
                bulletLevel = 4;
            }
        }
        if (collision.transform.gameObject.CompareTag("WingUpgrade"))
        {
            WingUpgrade.SetActive(true);
            winglevel += 1;
            Hp += totalHP - Hp;
        }
    }
}
public class Player : SingletonMonoBehaviour <PlayerController>
{

}