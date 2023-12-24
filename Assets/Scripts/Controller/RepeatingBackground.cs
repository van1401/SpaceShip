using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float verticalSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -verticalSize)
        {
            repositionBackground();
        }
    }
    void repositionBackground() 
    {
        Vector2 Offset = new Vector2(0, verticalSize * 2f);
        transform.position = (Vector2)transform.position + Offset;
    } 
}
