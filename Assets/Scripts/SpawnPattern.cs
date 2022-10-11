using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lifetime());
    }

    // Destroy Spawners
    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
