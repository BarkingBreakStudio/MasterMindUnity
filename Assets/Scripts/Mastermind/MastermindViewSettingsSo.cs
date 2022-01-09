using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Mastermind/ViewSettings")]
public class MastermindViewSettingsSo : ScriptableObject
{

    public Material[] CodePegMaterials = new Material[0];

    public Material[] KeyPegMaterials = new Material[0];

    private void Awake()
    {
        Debug.Log("MastermindViewSettingsSo Awake");
    }

    private void OnEnable()
    {
        Debug.Log("MastermindViewSettingsSo OnEnable");
    }

    private void OnValidate()
    {
        Debug.Log("MastermindViewSettingsSo OnValidate");
    }


}
