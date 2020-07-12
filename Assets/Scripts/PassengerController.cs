using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerController : MonoBehaviour
{
    public BoxCollider destinationArea;
    public GameObject destinationPrefab;
    public int passengersDelivered;

    private GameObject _currentDestination = null;

    void Start()
    {
        passengersDelivered = 0;
    }

    public void GenerateNewDestination()
    {
        if (_currentDestination != null)
        {
            return;
        }

        _currentDestination = Instantiate(destinationPrefab);

        var areaSize = destinationArea.size;
        Vector3 location = new Vector3(
            Random.Range(-areaSize.x * 0.5f, areaSize.x * 0.5f),
            0.1f,
            Random.Range(-areaSize.z * 0.5f, areaSize.z * 0.5f)
        );
        _currentDestination.transform.position = location;
    }


    public void DestinationReached()
    {
        passengersDelivered++;
        Destroy(_currentDestination);
    }
}
