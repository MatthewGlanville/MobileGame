using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RelativeUI : MonoBehaviour
{ 
   public Canvas canvas;

   public Image[] components;

    public RectTransform[] recttransform;

    private float[,] transformVals = new float [10,10];
    bool screenSet = false;
    float screenWidth;
    float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        components = canvas.GetComponentsInChildren<Image>();
        
        for (int i = 0; i < components.Length;i++)
        {
            float x = components[i].rectTransform.transform.position.x / canvas.pixelRect.width;
            Debug.Log(x);
        //    // do same for x axis
            float y = components[i].rectTransform.transform.position.y / canvas.pixelRect.height;
            float width = components[i].rectTransform.rect.width / canvas.pixelRect.width;
            Debug.Log(components[i].rectTransform.rect.width + " hhh");
            float height = components[i].rectTransform.rect.height / canvas.pixelRect.height;
            float[] vals = {x, y, width, height};
            transformVals[i,0] = vals[0];
            transformVals[i,1] = vals[1];
            transformVals[i,2]= vals[2];
            transformVals[i,3]= vals[3];


        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!screenSet)
        {
            for (int i = 0; i<components.Length; i++) //height code inspired by https://www.youtube.com/watch?v=QUz3SNh9f9M
            {
                components[i].rectTransform.transform.position = new Vector3(transformVals[i,0] * Screen.width,transformVals[i,1] *Screen.height,components[i].transform.position.z);
                components[i].rectTransform.sizeDelta = new Vector2(transformVals[i,2] * Screen.width, transformVals[i,3] * Screen.height);
            }
            screenSet = true;
        }
        if (Screen.width != screenWidth || Screen.height != screenHeight)
        {
            screenSet= false;
        }
        
        
    }
}
