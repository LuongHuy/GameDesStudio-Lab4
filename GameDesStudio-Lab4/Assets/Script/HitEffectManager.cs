using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DelayDestroyObject());
    }

    private IEnumerator DelayDestroyObject()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
