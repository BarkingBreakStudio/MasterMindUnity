using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    


    public void OpenUrlInBrowser(string url)
    {
        Application.OpenURL(url);
    }

}
