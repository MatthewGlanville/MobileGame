using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RelativeUI : MonoBehaviour
{ 
   public Canvas canvas;

   public Image[] components;

    public RectTransform[] recttransform;

    

    // Start is called before the first frame update
    void Start()
    {
        components = canvas.GetComponentsInChildren<Image>();
        
        for (int i = 0; i < components.Length;i++)
        {
            float x = components[i].rectTransform.transform.position.x / canvas.pixelRect.width;
            Debug.Log(x);
        //    // do same for x axis
            float y = components[i].rectTransform.transform.position.y / canvas.pixelRect.height;
            //float width = components[i].rectTransform.transform.width / canvas.pixelRect.width;
            //float height = components[i].rectTransform.sizeDelta.y / canvas.pixelRect.height;
            //    //list.add(x, width)


        }


    }

    // Update is called once per frame
    void Update()
    {

        //Graphics[int].recttransform.position.x = List.x
            
        //each axis
        
    }
}
