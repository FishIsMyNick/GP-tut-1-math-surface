using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FunctionLibrary;

public class Graph : MonoBehaviour
{
    [SerializeField]
    private Transform pointPrefab;
    [SerializeField, Range(0.1f, 10f)]
    private float range;
    [SerializeField, Range(1f, 1000f)]
    private int resolution;

    private Transform[] points;

    private void Awake()
    {
        float step = 2 * range / resolution;
        Vector3 sc = Vector3.one * step * 3;
        points = new Transform[(int)resolution];

        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            float x = (i + 0.5f) * step - range;
            float y = 0f;
            point.transform.localPosition = new Vector3(x, y, 0);
            point.localScale = sc;
            point.SetParent(transform);
            points[i] = point;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < resolution; i++)
        {
            Transform point = points[i];
            point.localPosition = new Vector3(point.localPosition.x, Ripple(point.localPosition.x, Time.time*2), 0);
        }
    }
}
