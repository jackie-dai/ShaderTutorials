using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform pointPrefab;
    [Tooltip("Resolution of line")]
    [SerializeField, Range(10, 100)] private int resolution = 10;
    [SerializeField, Range(1, 10)] private float frequency = 1f;

    Transform[] points;
    #endregion


    #region Unity Functions
    void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;
        points = new Transform[resolution];
        // Initializing all points
        for (int i = 0; i < resolution; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            point.SetParent(transform, false);
            point.localScale = scale;

            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
        }
    }

    void Update()
    {
        // Updating every point's y position with sin(x)
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(frequency * Mathf.PI *  (position.x + Time.time)); // where the magic happens
            Debug.Log("Time: " + Time.time);
            point.localPosition = position;
        }
    }

    #endregion
}
