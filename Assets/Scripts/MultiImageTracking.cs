using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultiImageTracking : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> dict;

    private void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            // Handle added event
            GameObject go = Instantiate(Resources.Load<GameObject>(newImage.referenceImage.name));
            go.transform.position = newImage.transform.position;
            go.transform.rotation = newImage.transform.rotation;

            dict.Add(newImage.referenceImage.name, go);
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Handle updated event
            if(dict.TryGetValue(updatedImage.referenceImage.name, out GameObject go));
            {
                go.transform.position = updatedImage.transform.position;
                go.transform.rotation = updatedImage.transform.rotation;
                go.SetActive(true);
            }
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
            if (dict.TryGetValue(removedImage.referenceImage.name, out GameObject go)) ;
            {
                dict.Remove(removedImage.referenceImage.name);
                Destroy(go);
            }
        }
    }
}
