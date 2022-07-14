using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private int x = 0;
    [SerializeField]
    private int y = 0;
    [SerializeField]
    private int z = 0;
    [SerializeField]
    private bool isRelativeRotation;
    private Space _isRelativeRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (isRelativeRotation)
            _isRelativeRotation = (Space)1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z, _isRelativeRotation);
    }
}
