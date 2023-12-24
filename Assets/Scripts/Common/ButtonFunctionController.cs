using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunctionController : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] GameObject Player3;
    [SerializeField] GameObject Background;

    private void Awake()
    {
        Time.timeScale = 0;
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Ship1()
    {
        Player1.SetActive(true);
        Background.SetActive(false);
        Time.timeScale = 1;
        this.PostEvent(EventID.choosePlayer);
    }
    public void Ship2()
    {
        Player2.SetActive(true);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void Ship3()
    {
        Player3.SetActive(true);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
       Time.timeScale = 1;
    }
}
