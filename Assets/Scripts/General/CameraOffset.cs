using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraOffset : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;

    // Position Offset
    public float x;
    public float y;
    public float z;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(x,y,z);
        camera.transform.position = transform.position + offset;
    }
}
