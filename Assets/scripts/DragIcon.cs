using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragIcon : MonoBehaviour
{
    [SerializeField] private Image icon; // inspired by my old code that was inspired by https://gamedevacademy.org/mobile-swipe-movement-tutorial/ (wasnt sure whether to credit it or not) 
    [SerializeField] private GameObject iconObject;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float extraBorder; //gives extra border so the icons are easier to drag and drop
    private Vector2 startPos;
    private Vector2 endPos;
    private bool fingerDown;
    public Image iconClone;
    private GameObject iconObjectClone;
    private bool draggingIcon;
    private Camera cam;
    private Vector3 iconPos;
    private RaycastHit hit;
    Vector3[] corners = new Vector3[4];
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        iconPos = iconObject.transform.position;
    }
    float getWidth(Image i)
    {
        return i.rectTransform.sizeDelta.x;
    }
    float getHeight(Image i)
    {
        return i.rectTransform.sizeDelta.y;
    }
    bool isInImage(Image i,Vector2 v)
    {

        float x = i.rectTransform.transform.position.x;
        float y = i.rectTransform.transform.position.y;
        i.rectTransform.GetWorldCorners(corners);
        Debug.Log(corners[3] + "WHY IS IT 0");
        float w = corners[3].x - corners[1].x;
        float h = corners[1].y - corners[0].y;
        Debug.Log("you are tapping" + v.x);
        Debug.Log("bottom border is for some reason" + w);
        Debug.Log("top border is for some reason" + (x  + w/2));
        if ((v.x>x - w/2 && v.x< x + w/2) && (v.y > y-h/2 && v.y < y + h/2))
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
            Debug.Log("WAUGUS");
            fingerDown = true;
        }
        else if (fingerDown && Input.touchCount > 0)
        {
            endPos = Input.touches[0].position;
        }
        if (fingerDown && Input.touchCount >0 && isInImage(icon,startPos) && !draggingIcon && this.gameObject.name == "Boulder (1)") 
        {
            if (iconClone == null)
            {
                iconClone = Instantiate(icon, startPos, Quaternion.identity);
                iconClone.transform.SetParent(canvas.transform, false);
            }
            else
            {
                iconClone.enabled = true;
            }
            
            draggingIcon = true;
            startPos = new Vector2(0, 0);
        }
        if (Input.touchCount > 0)
        {
            if ((Input.touches[0].phase == TouchPhase.Ended) && (draggingIcon))
            { 
                fingerDown = false;
                Debug.Log(Physics.Raycast(Input.touches[0].position, -Vector3.up, out hit));
                if (Physics.Raycast(cam.ScreenToWorldPoint(Input.touches[0].position), -Vector3.up, out hit))
                {
                    Debug.Log("hmm");
                    iconObjectClone = Instantiate(iconObject, hit.point, Quaternion.identity);
                }
                else
                {
                    Debug.Log(endPos);
                }
                draggingIcon = false;
                iconClone.enabled = false;
                Debug.Log(iconClone);

            }
            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                fingerDown = false;
            }
        }
        if (draggingIcon)
        {
            iconClone.rectTransform.transform.position = Input.touches[0].position;
            Debug.Log(iconClone);

        }

    }
}
