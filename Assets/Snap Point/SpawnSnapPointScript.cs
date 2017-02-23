using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class SpawnSnapPointScript : MonoBehaviour, IInputClickHandler {

    public GameObject snapPointPrefab;

    void Start () { }

	void Update () { }

    public void OnInputClicked(InputEventData eventData)
    {
        Vector3 spawnPoint = Vector3.Lerp(Camera.main.transform.position, transform.position, 0.5f);
        GameObject snapPpoint = Instantiate(snapPointPrefab, spawnPoint, Quaternion.identity);
        DentistItemScript script = snapPointPrefab.GetComponent<DentistItemScript>();
    }
}
