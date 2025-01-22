using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawner : MonoBehaviour
{
    public GameObject gasObject;
    public Transform spawnPoint;
    public float spawnTime = 4;
    public float moveSpeed = 15f;

    public enum SpawnPosition
    {
        left,
        middle,
        right,
    }

    public float[] offsets = { -4f, 0f, 4f };


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnGas),0f, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        spawnPoint.Translate(Vector3.back *moveSpeed* Time.deltaTime);

        foreach (Transform child in spawnPoint)
        {
            if(child.position.z<-20f)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void SpawnGas()
    {
        SpawnPosition spawnposition = (SpawnPosition)Random.Range(0, 3);

        float xPosition = offsets[(int)spawnposition];

        GameObject fuel = Instantiate(gasObject,spawnPoint);
        fuel.transform.position = new Vector3(xPosition, 0, 20f);
    }

   
}
