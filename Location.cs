using UnityEngine;

[CreateAssetMenu(fileName = "NewLocation", menuName = "Location")]
public class Location : ScriptableObject
{
    [SerializeField]
    public string title;
    
    [SerializeField]
    public string description;
    
    [SerializeField]
    public float lat;

    [SerializeField]
    public float lon;
};
