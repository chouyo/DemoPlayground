using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool showCube;
    public float startTime;
    public float delayTime;
    public float speed = 1.0f;
    public float from;
    public float to;
    // Start is called before the first frame update
    void Start()
    {
        showCube = false;
        //StartCoroutine(ShowCube());
    }

    // Update is called once per frame
    void Update()
    {
        if(showCube)
        {
            var t = Time.time - startTime;
            var y = Mathf.Lerp(from, to, t * speed);
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
    }

    public IEnumerator ShowCube()
    {
        from = this.transform.position.y;
        to = from + 1;
        yield return new WaitForSeconds(5 + delayTime);
        showCube = true;
        startTime = Time.time;

    }
}
