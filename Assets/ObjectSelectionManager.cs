using UnityEngine;
using UnityEngine.UI;

public class ObjectSelectionManager : MonoBehaviour
{
    public GameObject chairPrefab;
    public GameObject tablePrefab;
    public GameObject VasePrefab;
    public GameObject VadePrefab;
    private GameObject selectedObject;

    public void SelectChair()
    {
        selectedObject = chairPrefab;
    }

    public void SelectTable()
    {
        selectedObject = tablePrefab;
    }

    public void SelectVase()
    {
        selectedObject = VasePrefab;
    }
    public void SelectVed()
    {
        selectedObject = VadePrefab;
    }
    public GameObject GetSelectedObject()
    {
        return selectedObject;
    }
}
