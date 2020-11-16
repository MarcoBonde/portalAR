using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class RaycastTest : MonoBehaviour
{
    public GameObject PrefabToInstantiate;
    public ARPlaneManager PlaneManager;
    GameObject instantiatedObject;

    ARRaycastManager myRaycastManager;
    List<ARRaycastHit> planesHitList = new List<ARRaycastHit>();
    bool deactivatePlanesOnce;

    // Start is called before the first frame update
    void Start()
    {
        myRaycastManager = GetComponent<ARRaycastManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && instantiatedObject == null)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (myRaycastManager.Raycast(touchPosition, planesHitList, TrackableType.PlaneWithinPolygon))
            {
                Pose planeHitPose = planesHitList[0].pose;
                instantiatedObject = Instantiate(PrefabToInstantiate, planeHitPose.position, planeHitPose.rotation);
            }
        }

        if (instantiatedObject != null)
        {
            if (!deactivatePlanesOnce)
            {
                EnableDisableAllPlanes(false);
                deactivatePlanesOnce = true;
            }
        }
        else
        {
            if (deactivatePlanesOnce)
            {
                EnableDisableAllPlanes(true);
                deactivatePlanesOnce = false;
            }
        }
    }

    void EnableDisableAllPlanes(bool status)
    {
        GameObject[] allPlanesInScene = GameObject.FindGameObjectsWithTag("ARPlanes");
        for (int i = 0; i < allPlanesInScene.Length; i++)
        {
            allPlanesInScene[i].SetActive(status);
        }
        PlaneManager.enabled = status;
    }

    public void ResetSpawnedObject()
    {
        Destroy(instantiatedObject);
        instantiatedObject = null;
    }
}
