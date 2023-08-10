using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonUtils
{
   
    public static GameObject FindClosestObject(GameObject source, string tag)
    {
        GameObject[] objectsToCheck = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject obj in objectsToCheck)
        {
            float distanceToPlayer = Vector3.Distance(obj.transform.position, source.transform.position);

            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                closestObject = obj;
            }
        }
        return closestObject;
    }
}
