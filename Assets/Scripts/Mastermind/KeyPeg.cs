using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPeg : MonoBehaviour
{

    public MastermindViewSettingsSo vs;

    // Start is called before the first frame update
    void Start()
    {
        Color = -1; //hide peg
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int color;
    public int Color
    {
        get { return color; }
        set
        {
            color = value;
            var renderer = GetComponentInChildren<MeshRenderer>();
            if (Color >= 0)
            {
                renderer.sharedMaterial = vs.KeyPegMaterials[color];
                renderer.enabled = true;
            }
            else
            {
                renderer.enabled = false;
            }
        }
    }

    [ContextMenu("SetColor-1")]
    private void SetColorm1()
    {
        Color = -1;
    }

    [ContextMenu("SetColor0")]
    private void SetColor0()
    {
        Color = 0;
    }

    [ContextMenu("SetColor1")]
    private void SetColor1()
    {
        Color = 1;
    }
}
