using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageTracking : MonoBehaviour
{
    [SerializeField]ARTrackedImageManager arTrackedImageManager;
    [SerializeField] GameObject spherePrefab;
    GameObject instantiatedObject;

    void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(var trackedImage in eventArgs.added)
        {
            if(trackedImage.referenceImage.name == "Logo_NHL")
            {
                Debug.Log("------ADDED-------");
                instantiatedObject = Instantiate(spherePrefab,
                    trackedImage.transform.position,
                    trackedImage.transform.rotation);
            }
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            if (updatedImage.referenceImage.name == "Logo_NHL")
            {
                Debug.Log("------UPDATED-------");

                instantiatedObject.transform.position = updatedImage.transform.position;
                instantiatedObject.transform.rotation = updatedImage.transform.rotation;
            }
        }



    }
}