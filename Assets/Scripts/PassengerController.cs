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

        var extents = destinationPrefab.GetComponent<BoxCollider>().size * 0.5f;
        var layermask = LayerMask.GetMask("Death");
        Debug.LogFormat("Extents: {0}, layermask {1}", extents, layermask);
        // var collider = _currentDestination.GetComponent<BoxCollider>();

        _currentDestination = Instantiate(destinationPrefab);


        var areaSize = destinationArea.size;
        Vector3 location;

        // var hits = Physics.OverlapBox(location, extents, Quaternion.identity, layermask);
        do
        {
            location = new Vector3(
                            Random.Range(-areaSize.x * 0.5f, areaSize.x * 0.5f),
                            0.1f,
                            Random.Range(-areaSize.z * 0.5f, areaSize.z * 0.5f)
                        );
        } while (Physics.CheckBox(location, extents, Quaternion.identity, layermask));
        _currentDestination.transform.position = location;
    }


    public void DestinationReached()
    {
        passengersDelivered++;
        Destroy(_currentDestination);
    }
}
