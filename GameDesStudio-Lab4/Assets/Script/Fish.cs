using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : EnemyClass
{
    public GameObject bulletPrefab;
    GameObject bulletActual;
    public float spawnLower;
    public float spawnUpper;

    [SerializeField] AudioClip audioClip;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Action());
    }

    public IEnumerator Action()
    {
        // wait for random second
        float interval = Random.Range(spawnLower, spawnUpper); 
        yield return new WaitForSeconds(interval);
        
        // play sound effect
        //SoundManager.Instance.playVFX(audioClip, transform);

        // reset bullet position before firing
        Vector2 bulletPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f);
        bulletActual = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
        bulletActual.SetActive(true);
    }

    public override GameObject DeepClone(Vector2 clonePos)
    {
        GameObject clone = Instantiate(gameObject, clonePos, Quaternion.identity);

        return clone;
    }
}
