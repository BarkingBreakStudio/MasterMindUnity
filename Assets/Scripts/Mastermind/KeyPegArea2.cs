using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPegArea2 : MonoBehaviour
{
    public KeyPeg[] KeyPegs = new KeyPeg[0];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKeyPegColors(int[] colors)
    {
        for (int i = 0; i < Math.Min(KeyPegs.Length, colors.Length); i++)
        {
            KeyPegs[i].Color = colors[i];
        }
    }
}
