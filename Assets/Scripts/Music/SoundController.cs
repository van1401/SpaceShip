using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;


public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    [Header("Music Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio clip")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip shooting;
    public AudioClip shield;
    public AudioClip levelup;
    public AudioClip healthPickUp;
    public AudioClip upgradeItem;
    public AudioClip enemyExplosion;
    public AudioClip enemyExplosion2;
    public AudioClip bossExplosion;





    public void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }



    void Start()
    {
        musicSource.clip = background;
        //musicSource1.clip = background1;
        //musicSource2.clip = background2;
        musicSource.Play();
        //if (SceneManager.GetActiveScene().name == "GameScene1")
        //{
        //    musicSource.Stop();
        //    musicSource1.Play();
            //SoundController.instance.GetComponent<AudioSource>().Pause();
     }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
public class SoundControl : SingletonMonoBehaviour<SoundController>
{

}