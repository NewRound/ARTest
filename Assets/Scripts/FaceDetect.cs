using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class FaceDetect : MonoBehaviour
{
    ARFaceManager faceManager;
    public GameObject facePref;
    public Text text;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
        faceManager.facesChanged += OnDetect;
        text.text = index.ToString();
    }

    void OnDetect(ARFacesChangedEventArgs args)
    {
        if(args.updated.Count > 0)
        {
            Vector3 pos = args.updated[0].vertices[index];
            pos = args.updated[0].transform.TransformPoint(pos);
            facePref.SetActive(true);
            facePref.transform.position = pos;
        }
        else
        {
            facePref.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        index++;
        text.text = index.ToString();
    }
}
