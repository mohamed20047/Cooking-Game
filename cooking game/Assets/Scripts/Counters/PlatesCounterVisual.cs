using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform PlateVisualPrefab;


    private List<GameObject> PlateVisualGameObjectList;

    private void Awake()
    {
        PlateVisualGameObjectList = new List<GameObject>();
    }
    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject PlateGameObject = PlateVisualGameObjectList[PlateVisualGameObjectList.Count - 1];
        PlateVisualGameObjectList.Remove(PlateGameObject);
        Destroy(PlateGameObject);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform PlateVisualTransform = Instantiate(PlateVisualPrefab, counterTopPoint);

        float PlateOffsetY = .1f;
        PlateVisualTransform.localPosition = new Vector3(0, PlateOffsetY * PlateVisualGameObjectList.Count, 0);

        PlateVisualGameObjectList.Add(PlateVisualTransform.gameObject);
    }
}

