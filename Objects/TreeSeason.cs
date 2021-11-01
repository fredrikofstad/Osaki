using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeason : MonoBehaviour
{
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
    public Season currentSeason = Season.Autumn;
    public Texture[] textures;




    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = textures[(int)currentSeason];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
