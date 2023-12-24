using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using Core.Pool;

public class EffectController : MonoBehaviour
{
    public float time;
    private void Update()
    {
        StartCoroutine(destroyHitEffect());
    }

    public IEnumerator destroyHitEffect()
    {
        yield return new WaitForSeconds(time);
        SmartPool.Instance.Despawn(this.gameObject);
    }
}
