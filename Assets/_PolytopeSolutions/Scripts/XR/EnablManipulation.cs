using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablManipulation : MonoBehaviour
{
    private ObjectManipulator[] manipulatableObjects;
    private Vector3[] positions;
    private Quaternion[] rotations;
    public bool startManipualtionEnabled;
    private bool manipulationEnabled;
    // Start is called before the first frame update
    void Start()
    {
        manipulatableObjects = GetComponentsInChildren<ObjectManipulator>();
        positions = new Vector3[manipulatableObjects.Length];
        rotations = new Quaternion[manipulatableObjects.Length];
        for (int i = 0; i < manipulatableObjects.Length; i++){
            positions[i] = manipulatableObjects[i].transform.localPosition;
            rotations[i] = manipulatableObjects[i].transform.localRotation;
        }
        if (startManipualtionEnabled)
            ToggleManipulation();
    }

    public void ToggleManipulation() {
        manipulationEnabled = !manipulationEnabled;
        for (int i = 0; i < manipulatableObjects.Length; i++)
        {
            if (manipulationEnabled)
            {
                manipulatableObjects[i].enabled = true;
            }
            else { 
                manipulatableObjects[i].transform.localPosition = positions[i];
                manipulatableObjects[i].transform.localRotation = rotations[i];
                manipulatableObjects[i].enabled = false;
            }
        }
    }
}
