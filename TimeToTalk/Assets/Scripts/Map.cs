using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public float MapSpeed = 0.5f;
    float Target_Offset;
    Renderer MapTexture;

    private void Awake()
    {
        MapTexture = GetComponent<Renderer>();
    }

    void Update ()
    {
        Target_Offset += Time.deltaTime * MapSpeed;
        MapTexture.material.mainTextureOffset = new Vector2(Target_Offset, 0);
    }
}
