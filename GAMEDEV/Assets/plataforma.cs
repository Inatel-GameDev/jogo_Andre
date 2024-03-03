using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{

    public float target1 = 1.0f;
    bool target1_1= false;
    public float target2 = -1.5f;
    bool target2_1= true;

    float speed = 0.7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        if(target2_1)
        {
            float angle = Mathf.MoveTowardsAngle(transform.position.y, target1, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, angle, transform.position.z);
            if(transform.position.y == target1)
            {
                target2_1 = false;
                target1_1 = true;
            }
        }
        else if(target1_1)
        {
            float angle = Mathf.MoveTowardsAngle(transform.position.y, target2, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, angle, transform.position.z);
            if(transform.position.y == target2)
            {
                target1_1 = false;
                target2_1 = true;
            }
        }
        
    }
}
