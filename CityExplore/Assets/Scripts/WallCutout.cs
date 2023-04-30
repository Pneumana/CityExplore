using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCutout : MonoBehaviour
{
    public Transform targetObject;
    private LayerMask wall;
    private Camera mainCamera;
    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= (Screen.width/Screen.height);
        Vector3 offset = targetObject.position - transform.position;
        RaycastHit[] hitObjects = Physics.RaycastAll(transform.position, offset, offset.magnitude, wall);

        for(int i = 0; i < hitObjects.Length; i++)
        {
            Material[] mats = hitObjects[i].transform.GetComponent<Renderer>().materials;
            for(int n = 0; n < mats.Length; i++)
            {
                mats[n].SetVector("_CutoutPosition", cutoutPos);
                mats[n].SetFloat("_CutoutSize", 0.1f);
                mats[n].SetFloat("_CutoutFalloff", 0.05f);
            }
        }
    }
}
