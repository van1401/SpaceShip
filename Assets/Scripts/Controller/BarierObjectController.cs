using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
public class BarierObjectController : MonoBehaviour
{

    public GameObject[] planets;
    public Transform[] _gate;
    public float timeBetweenPlanets;

    private void Start()
    {
        StartCoroutine(CreatePlanets());

    }
    private void OnEnable()
    {

    }
    public void Update()
    {
    }



    IEnumerator CreatePlanets()
    {
        while (true)
        {
            int randomPlanets = Random.Range(0, planets.Length);
            int randomPoint = Random.Range(0, _gate.Length);
            Instantiate(planets[randomPlanets], _gate[randomPoint].transform.position, transform.rotation);
            yield return new WaitForSeconds(timeBetweenPlanets);
        }
    }
}
   

