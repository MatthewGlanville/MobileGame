using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragIcon : MonoBehaviour
{
    [SerializeField] private Image icon; // inspired by my old code that was inspired by https://gamedevacademy.org/mobile-swipe-movement-tutorial/ (wasnt sure whether to credit it or not) 
    [SerializeField] private GameObject iconObject;
    [SerializeField] private Canvas canvas; 
    private Vector2 startPos;
    private Vector2 endPos;
    private bool fingerDown;
    private Image iconClone;
    private GameObject iconObjectClone;
    private bool draggingIcon;
    private Camera cam;
    private Vector3 iconPos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        iconPos = iconObject.transform.position;
    }
    float getWidth(Image i)
    {
        return i.rectTransform.rect.width;
    }
    float getHeight(Image i)
    {
        return i.rectTransform.rect.height;
    }
    bool isInImage(Image i,Vector2 v)
    {
        float w = getWidth(i);
        float h = getHeight(i);
        float x = i.rectTransform.transform.position.x;
        float y = i.rectTransform.transform.position.y;
        if (v.y < 150)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            Debug.Log(startPos);
            fingerDown = true;
        }
        else if (fingerDown && Input.touchCount > 0)
        {
            endPos = Input.touches[0].position;
        }
        if (fingerDown && Input.touchCount >0 && isInImage(icon,startPos) && !draggingIcon) 
        {
            iconClone = Instantiate(icon, startPos, Quaternion.identity);
            iconClone.transform.SetParent(canvas.transform, false);
            draggingIcon = true;
            startPos = new Vector2(0, 0);
        }
        if (Input.touchCount > 0)
        {
            if ((Input.touches[0].phase == TouchPhase.Ended) && (draggingIcon))
            { 
                fingerDown = false;
                iconObjectClone = Instantiate(iconObject, iconPos, Quaternion.identity);
                draggingIcon = false;
                Destroy(iconClone); 

            }
        }
        if (draggingIcon)
        {
            iconClone.rectTransform.transform.position = Input.touches[0].position;
            Debug.Log(iconClone);

        }

    }
}
