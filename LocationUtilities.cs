using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationUtilities : MonoBehaviour 
{   
    static public float EARTH_RADIUS = 6371.0f;

    //https://stackoverflow.com/questions/6366408/calculating-distance-between-two-latitude-and-longitude-geocoordinates
    static public float Haversine(ref Location destination, ref Location current)
    {
        float newLatitude = destination.lat;
        float newLongitude = destination.lon;
        float deltaLatitude = (newLatitude - current.lat) * Mathf.Deg2Rad;
        float deltaLongitude = (newLongitude - current.lon) * Mathf.Deg2Rad;
        
        float a = Mathf.Pow(Mathf.Sin(deltaLatitude / 2), 2) + Mathf.Cos(current.lat * Mathf.Deg2Rad) * Mathf.Cos(newLatitude * Mathf.Deg2Rad) *
            Mathf.Pow(Mathf.Sin(deltaLongitude / 2), 2);
        
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        //Debug.Log("distance: " + (EARTH_RADIUS * c));
        
        return EARTH_RADIUS * c;
    }

    static public float CalculateAngle(Location startPoint, Location endPoint)
    {
        float dLon = endPoint.lon - startPoint.lon;

        float y = Mathf.Sin(dLon) * Mathf.Cos(endPoint.lat);
        float x = Mathf.Cos(startPoint.lat) * Mathf.Sin(endPoint.lat) - Mathf.Sin(startPoint.lat)
                * Mathf.Cos(endPoint.lat) * Mathf.Cos(dLon);

        double brng = Mathf.Atan2(y, x);

        brng = brng * Mathf.Rad2Deg;
        brng = (brng + 360) % 360;
        brng = 360 - brng;

        float heading = 90.0f;//Input.compass.trueHeading;

        return (float)brng - heading;
    }
}
