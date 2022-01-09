using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecureCodeArea : MonoBehaviour
{

    public CodePeg[] SecureCodePegs = new CodePeg[0];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColors(int[] colors)
    {
        for (int i = 0; i < Math.Min(colors.Length, SecureCodePegs.Length); i++)
        {
            SecureCodePegs[i].Color = colors[i];
        }
    }

}
