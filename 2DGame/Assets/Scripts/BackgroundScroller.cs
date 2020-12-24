using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] float backgroundScrollSpeed = 0.2f;

    //the Material from the texture
    Material myMaterial;

    //movement offSet
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        //get the material of the background from Renderer component
        myMaterial = GetComponent<Renderer>().material;

        //move in the y-axis at the given speed
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //move the texture of the material by offSet every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
