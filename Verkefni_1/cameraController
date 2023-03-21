using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Það er kallað á 'Start' á undan fyrsta 'frame update'
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Það er kallað á 'Update' einusinni hvern 'frame'
    void LateUpdate()
    {
        // breytir staðsetningu myndavélarinnar
        transform.position = player.transform.position + offset;
    }
}
