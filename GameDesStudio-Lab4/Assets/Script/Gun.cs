using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet Bullet;
    public Transform findTransform;
    private float tempDelayTime;
    public float delayTime;
    public AudioClip fire;
    private void Shoot()
    {
        if (tempDelayTime > Time.time)
        {
            return;
        }
        tempDelayTime = Time.time + delayTime;

        Instantiate(Bullet,findTransform.position,Quaternion.identity);
        SoundManager.Instance.playVFX(fire,transform);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
        Shoot();
        }
    }
}
