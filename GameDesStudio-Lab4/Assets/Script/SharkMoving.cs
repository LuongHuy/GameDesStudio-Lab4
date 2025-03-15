using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera cam;
    public SpriteRenderer spriteRenderer;
    private float spriteWidth;

    private void Start()
    {
        spriteWidth = spriteRenderer.bounds.extents.x;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0f, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        var screenBound = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        var viewpost = transform.position;
        viewpost.x = Mathf.Clamp(viewpost.x, -screenBound.x + spriteWidth, screenBound.x - spriteWidth);
        //viewpost.x = Mathf.Clamp(viewpost.y, -screenBound.y + spriteWidth, screenBound.y - spriteWidth);
        transform.position = viewpost;
    }
}
