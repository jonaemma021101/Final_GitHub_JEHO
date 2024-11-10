using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject chairPrefab;
    public GameObject bedPrefab;
    public GameObject vadePrefab;
    public GameObject vasePrefab;
    private GameObject selectedObjectPrefab;
    private GameObject spawnedObject;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Método para seleccionar la silla
    public void SelectChair()
    {
        selectedObjectPrefab = chairPrefab;
    }
    public void SelectVade()
    {
        selectedObjectPrefab = vadePrefab;
    }

    public void SelectVase()
    {
        selectedObjectPrefab = vasePrefab;
    }
    // Método para seleccionar la cama
    public void SelectBed()
    {
        selectedObjectPrefab = bedPrefab;
    }

    void Update()
    {
        if (selectedObjectPrefab != null && raycastManager != null)
        {
            // Detectar toque en la pantalla
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
                {
                    // Obtener la posición del impacto
                    Pose hitPose = hits[0].pose;

                    // Si ya hay un objeto en la escena, lo destruye
                    if (spawnedObject != null)
                    {
                        Destroy(spawnedObject);
                    }

                    // Instanciar el objeto seleccionado
                    spawnedObject = Instantiate(selectedObjectPrefab, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
