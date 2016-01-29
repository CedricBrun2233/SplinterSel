using UnityEngine;
using System.Collections;

public class PlayerGrapProp : MonoBehaviour {

    public float throwForce = 0;
    private Rigidbody propToGrabRB;
    private Collider propToGrabcol;
    private GameObject propFinish;
    private Vector3 initScale;
    private bool grabbed = false;
    private bool disabled = false;
    private bool itemFinishInStock = false;

    public void disableGrab()
    {
        disabled = true;
    }

    public void enableGrab()
    {
        disabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Item")
        {
            propToGrabRB = col.gameObject.GetComponent<Rigidbody>();
            propToGrabcol = col.GetComponent<Collider>();
        }

        if (col.transform.tag == "Finish")
        {
            propFinish = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Item")
        {
            propToGrabRB = null;
            propToGrabcol = null;
        }

        if (col.transform.tag == "Finish")
        {
            propFinish = null;
        }
    }

    public bool hasWin()
    {
        return itemFinishInStock;
    }



	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
	void FixedUpdate () {
        if (Input.GetButtonDown("Grab") && !disabled)
        {
            if(propToGrabRB != null)
            {
                if (grabbed)
                {
                    propToGrabRB.transform.parent = null;
                    propToGrabRB.transform.localScale = initScale;
                    propToGrabRB.isKinematic = false;
                    propToGrabcol.enabled = true;
                    Vector3 throwDir = this.transform.forward;
                    throwDir.y = 0.2f;
                    propToGrabRB.AddForce(throwDir * throwForce, ForceMode.Impulse);
                    propToGrabRB.AddTorque(new Vector3(0, 10, 10), ForceMode.Impulse);
                    grabbed = false;
                }
                else
                {
                    initScale = propToGrabRB.transform.localScale;
                    propToGrabRB.transform.parent = this.gameObject.transform;
                    propToGrabRB.isKinematic = true;
                    propToGrabcol.enabled = false;
                    propToGrabRB.transform.position = new Vector3(propToGrabRB.transform.position.x, this.transform.position.y * 1.2f, propToGrabRB.transform.position.z);
                    grabbed = true;
                }
            }
                
            if(propFinish != null)
            {
                propFinish.SetActive(false);
                itemFinishInStock = true;
            }
        }
	}
}
