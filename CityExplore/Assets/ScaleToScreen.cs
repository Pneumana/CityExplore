using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleToScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var recttransform = gameObject.GetComponent<RectTransform>();
        recttransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
