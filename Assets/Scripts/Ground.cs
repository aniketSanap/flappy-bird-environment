﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Renderer rend;

    [SerializeField]
    private float scrollSpeed = 5f;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        Vector2 currentTextureOffset = rend.material.GetTextureOffset("_MainTex");
        float distanceToScrollLeft = Time.deltaTime * scrollSpeed;
        float newXOffset = currentTextureOffset.x + distanceToScrollLeft;

        Vector2 newOffset = new Vector2(newXOffset, currentTextureOffset.y);
        rend.material.SetTextureOffset("_MainTex", newOffset);
    }
}
