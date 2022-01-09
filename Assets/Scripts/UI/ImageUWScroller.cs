using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageUWScroller : MonoBehaviour
{

    private RawImage rawImage;

    public float X;
    public float Y;

    // Start is called before the first frame update
    void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        Rect curRect = rawImage.uvRect;
        curRect.x += X * Time.deltaTime;
        curRect.y += Y * Time.deltaTime;
        rawImage.uvRect = curRect;
    }
}
