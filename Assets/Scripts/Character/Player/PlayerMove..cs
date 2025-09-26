using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float m_fVelocity = 1.0f;//速度
    public float m_fHeight = 0.0f;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        GameObject camera = GameObject.Find("Main Camera");

        Vector3 move = Vector3.zero;

        //移動処理
        if(Input.GetKey(KeyCode.W))
        {
            move += camera.transform.forward * m_fVelocity;
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            move -= camera.transform.forward * m_fVelocity;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move += camera.transform.right * m_fVelocity;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move -= camera.transform.right * m_fVelocity;
        }

        // move.y = 0.0f;
        move = move.normalized;
        move = move * m_fVelocity;

        rigidbody.AddForce(move.x, 0.0f, move.z);
    }

    private void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        Vector3 pos = transform.position;
        pos.y += 0.3f;

        Ray ray = new Ray(transform.position, new Vector3(0.0f, -1.0f, 0.0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidbody.AddForce(0.0f, m_fHeight, 0.0f, ForceMode.Impulse);
            }
            else if (rigidbody.velocity.y <= 0.0f)
            {

            }
        }
    }
}
