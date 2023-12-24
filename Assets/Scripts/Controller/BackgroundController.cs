using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public static BackgroundController instance;
    private Vector2 startPos;
    public float scrollspeed;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Start()
    {
        startPos = transform.position;
    }
    private void movingBackground()
    {
        transform.Translate(Vector3.up * scrollspeed * Time.deltaTime);
        //if (transform.position.y < -50f)
        //{
        //    transform.position = startPos;
        //}
        //float newPos = Mathf.Repeat(Time.time * scrollspeed, 10);
        //transform.position = startPos - new Vector2(0, 1) * newPos;
    }
    private void Update()
    {
        movingBackground();
    }
}
