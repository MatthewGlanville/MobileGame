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
    [SerializeField] private string name;
    [SerializeField] private GameManager gameManager;
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
        i.rectTransform.GetWorldCorners(corners);
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
        float w = corners[3].x - corners[1].x;
        float h = corners[1].y - corners[0].y;
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
            fingerDown = true;
        }
        else if (fingerDown && Input.touchCount > 0)
        {
            endPos = Input.touches[0].position;
        }
        if (fingerDown && Input.touchCount >0 && isInImage(icon,startPos) && !draggingIcon && this.gameObject.name == name) 
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
                Vector3 touchPos = new Vector3(Input.touches[0].position.x + cam.transform.position.x - Screen.width/2, 0, Input.touches[0].position.y + cam.transform.position.z-Screen.height/2);
                //
                Debug.Log(Physics.Raycast(cam.transform.position, -Vector3.up, out hit));
                if (Physics.Raycast(touchPos, -Vector3.up, out hit) && gameManager.Money>=10)
                {
                    gameManager.Money -= 10;
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
