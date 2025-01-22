using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Transform[] grounds;
    public float resetPosition = -10f;
    public float moveSpeed = 20f;
    public float groundLength = 10f;

    // Update is called once per frame
    void Update()
    {
        foreach(Transform ground in grounds)
        {
            ground.Translate(Vector3.back * moveSpeed*Time.deltaTime);

            if (ground.position.z <= resetPosition)
            {
                Vector3 newPosition = ground.position;
                newPosition.z += groundLength * grounds.Length; // 뒤로 재배치
                ground.position = newPosition;
            }

        }
    }
}
