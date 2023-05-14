using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Mover : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("sawbladeSprite")] private Transform sprite;
    [SerializeField] Transform startTransform;
    [SerializeField] Transform endTransform;
    [SerializeField] private float sawSpeed = 2;

    private float positionPercent;
    
    private int direction = 1;
    private float distance;
    private void Awake()
    {
        distance = Vector3.Distance(startTransform.position, endTransform.position);
    }

    private void Update()
    {

        float speedForDistance = sawSpeed/distance;
        positionPercent += Time.deltaTime * direction * sawSpeed * speedForDistance;

        sprite.position = Vector3.Lerp(startTransform.position, endTransform.position, positionPercent);

        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }
        else if (positionPercent <= 0 && direction == -1)
        {
            direction = 1;
        }
    }
}
