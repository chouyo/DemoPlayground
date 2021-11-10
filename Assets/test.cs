using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public float x = 10.0f;
    private Cube[] cubes;
    float startTime;
    public float speed = 5.0f;
    void Start()
    {
        startTime = Time.time;
        cubes = GetComponentsInChildren<Cube>();
        foreach(var cube in cubes)
        {
            cube.delayTime = Random.Range(0.0f, 3.0f);
            // StartCoroutine(cube.ShowCube());
            Debug.Log(cube.delayTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / 5.0f;
        x -= Time.deltaTime * speed;
        if(x > -10) 
        {
        // x = 10;
            foreach(var cube in cubes)
            {
                var width = x - cube.transform.position.x;
                // if(   width < 1 && width > 0)
                {
                    var y = -Mathf.SmoothStep(0,1, Mathf.Abs(width));
                    cube.transform.position = new Vector3(cube.transform.position.x,y,cube.transform.position.z);
                }

            }
        }
        else
        {
            foreach(var cube in cubes)
            {
                if(cube.showCube == false)
                {
                    StartCoroutine(cube.ShowCube());
                }
            }
        }
    }
}
