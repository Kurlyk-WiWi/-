using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Locations : MonoBehaviour
{
    public List<Sprite> locations;
    //public string characterName;
    private Vector3 defaultScale;
    public Vector3 DefaultScale => defaultScale;
    private void OnEnable()
    {
        defaultScale = transform.localScale;
    }
    public void ChangeLocation(int currentLocation)
    {
        GetComponent<Image>().sprite = locations[currentLocation];
    }
    public void ChangeScale(float multiplier)
    {
        transform.localScale *= multiplier;
    }
    public void ResetScale()
    {
        transform.localScale = defaultScale;
    }
}