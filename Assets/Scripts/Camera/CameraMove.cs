using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float Mouse = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 pos = player.transform.position;

        transform.RotateAround(pos, Vector3.up, mouseX * Mouse);

        transform.RotateAround(pos, transform.right, mouseY * Mouse);

        pos += transform.forward * -2.5f;

        pos.y += 1.5f;

        pos.z -= 2.5f;
        pos.y += 0.5f;

        transform.position = pos;
    }
}
