using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasItem : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddGas();
        }
    }
}
