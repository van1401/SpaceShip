using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
using LTAUnityBase.Base.DesignPattern;

public class Boundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.transform.gameObject);
            //SmartPool.Instance.Despawn(collision.gameObject);
        }
        if (collision.tag == "EnemyBullet")
        {
            Destroy(collision.transform.gameObject);
            //SmartPool.Instance.Despawn(collision.gameObject);
        }
        if (collision.tag == "BossBullet")
        {
            Destroy(collision.transform.gameObject);
            //SmartPool.Instance.Despawn(collision.gameObject);
        }
        if (collision.tag == "HealthPotion")
        {
            Destroy(collision.transform.gameObject);
            //SmartPool.Instance.Despawn(collision.gameObject);
        }
        if (collision.tag == "UpgradePotion")
        {
            Destroy(collision.transform.gameObject);
            //SmartPool.Instance.Despawn(collision.gameObject);
        }
        if (collision.tag == "ShieldPotion")
        {
            Destroy(collision.transform.gameObject);
            //SmartPool.Instance.Despawn(collision.gameObject);
        }
        if (collision.tag == "Planets")
        {
            Destroy(collision.transform.gameObject);
        }
    }
}
