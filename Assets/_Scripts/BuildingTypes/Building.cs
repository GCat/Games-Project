using UnityEngine;
using System.Collections;
using System;

public abstract class Building : MonoBehaviour, HealthManager{ // this should also be placeable hence the grab and release will be written once
    public abstract string getName();
    public abstract Vector3 getLocation();
    public abstract void create_building();
    public float totalHealth = 100.0f;
    public float health = 100.0f;
    public ResourceCounter resourceCounter;
    public GameObject tablet;
    GameObject healthBar;
    GameObject infoText;
    private Vector3 boxSize;
    public GameObject highlight;
    public Material matEmpty;
    public Material matInval;
    public bool canBeGrabbed = true;
    protected Renderer[] child_materials;
    protected Shader outlineShader;

    public abstract bool canBuy();

    public void decrementHealth(float damage)
    {
        if (!healthBar.activeSelf) healthBar.SetActive(true);
        health -= damage;
        float scale = (health / totalHealth);
        healthBar.transform.localScale = new Vector3(1.0f, scale * 10f, 1.0f);
        if (scale != 0) healthBar.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f-scale, scale, 0));

        if (health <= 0)
        {
            die();
        }else if(health <= (0.2 * totalHealth))
        {
            setWarning();
        }
    }

    private void Awake()
    {
        tablet = GameObject.FindGameObjectWithTag("Tablet");
        if (tablet != null)
        {
            resourceCounter = (ResourceCounter)tablet.GetComponent<ResourceCounter>();
        }
        else Debug.Log("Tablet not found");
        createHealthBar();
        createInfoText();
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 1f;
        child_materials = GetComponentsInChildren<Renderer>();
        outlineShader = Shader.Find("Toon/Basic Outline");
    }

    //return true if within bounds & not above another building
    public bool canPlace()
    {

        float x = transform.position.x;
        float z = transform.position.z;

        int layerMask = 1 << 10;
        if (resourceCounter.withinBounds(transform.position))
        {
            GetComponent<Collider>().enabled = true;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(x), 0, Mathf.Floor(z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
            {
                return false;
            }
            return true;
        }
        return false;
    }


    private void setOutline()
    {
        foreach(Renderer renderer in child_materials)
        {
            renderer.material.shader = outlineShader;
            renderer.material.SetColor("_OutlineColor", Color.green);
        }
    }

    private void setWarning()
    {
        foreach (Renderer renderer in child_materials)
        {
            renderer.material.shader = outlineShader;
            renderer.material.SetColor("_OutlineColor", Color.red);
        }
    }

    public void removeOutline()
    {
        foreach (Renderer renderer in child_materials)
        {
            renderer.material.shader = Shader.Find("Diffuse");
            //renderer.material.SetColor("_OutlineColor", Color.green);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            setOutline();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
        }
    }

    public void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        Debug.Log("Resource Building vel:" + vel);
        GetComponent<Rigidbody>().AddForce(vel, ForceMode.VelocityChange);
        removeOutline();
    }

    public IEnumerator ResourceGainText(int value,string resource)
    {
        Vector3 cameraPos = GameObject.FindWithTag("MainCamera").transform.position;
        GameObject resourceText = GameObject.Instantiate(infoText,infoText.transform) as GameObject;
        resourceText.transform.parent = gameObject.transform;
        Vector2 randPos = UnityEngine.Random.insideUnitCircle*15.0f;
        resourceText.transform.Translate(new Vector3(randPos.x,-2.0f,randPos.y));
        Vector3 startLocation = resourceText.transform.position;
        cameraPos.y = startLocation.y;
        Debug.Log(cameraPos.y);
        resourceText.transform.LookAt(2*startLocation - cameraPos);
        Debug.Log(startLocation.y);
        resourceText.GetComponent<TextMesh>().text = "+" + value.ToString() + " " + resource;
        Color c;
        resourceText.SetActive(true);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            c = resourceText.GetComponent<TextMesh>().color;
            c.a = f;
            resourceText.GetComponent<TextMesh>().color = c;
            resourceText.transform.Translate(new Vector3(0, 0.1f, 0));
            yield return null;
        }
        resourceText.SetActive(false);
        GameObject.Destroy(resourceText);
        /*
        infoText.transform.position = startLocation;
        c = infoText.GetComponent<TextMesh>().color;
        c.a = 1.0f;
        infoText.GetComponent<TextMesh>().color = c;
        */
    }

    public GameObject getInfoText()
    {
        return infoText;
    }

    public void createHealthBar()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        healthBar = GameObject.Instantiate(Resources.Load("HealthBar")) as GameObject;
        healthBar.transform.position = gameObject.GetComponent<Collider>().transform.position;
        healthBar.transform.Translate(new Vector3(0, actualSize.y*1.5f, 0));
        healthBar.transform.localRotation = gameObject.transform.localRotation;
        healthBar.transform.Rotate(new Vector3(90, 0, 0));
        healthBar.transform.SetParent(gameObject.transform);
        healthBar.SetActive(false);
    }

    public void createInfoText()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        infoText = GameObject.Instantiate(Resources.Load("Info_Text")) as GameObject;
        infoText.transform.position = gameObject.transform.position;
        infoText.transform.localScale *= 2;
        infoText.transform.Translate(new Vector3(0, actualSize.y * 1.3f, 0));
        infoText.transform.localRotation = gameObject.transform.localRotation;
        infoText.transform.Rotate(new Vector3(0, -90, 0));
        infoText.transform.SetParent(gameObject.transform);
        infoText.SetActive(false);
    }

    public void highlightCheck()
    {
        if (transform.position.y > 0.0 && Mathf.Abs(transform.position.x) <= 50 && Mathf.Abs(transform.position.z) <= 100)
        {
            highlight.GetComponent<Renderer>().enabled = true;
            highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
            float yRot = gameObject.transform.eulerAngles.y;
            if ((yRot > 45 && yRot < 135) || (yRot > -135 && yRot < -45))
            {
                highlight.transform.rotation = Quaternion.LookRotation(Vector3.right);

            }
            else
            {
                highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            }
            int layerMask = 1 << 10;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(transform.position.x), 0, Mathf.Floor(transform.position.z)), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
                highlight.GetComponent<Renderer>().material = matInval;
            else
                highlight.GetComponent<Renderer>().material = matEmpty;
        }
        else
        {
            highlight.GetComponent<Renderer>().enabled = false;
        }
    }

    public void highlightDestroy()
    {
        if (highlight != null) Destroy(highlight);
    }



    public void createHighlight()
    {
        highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        highlight.GetComponent<Renderer>().material = matEmpty;
        highlight.transform.localScale = new Vector3(GetComponent<BoxCollider>().bounds.size.x, 0.1f, GetComponent<BoxCollider>().bounds.size.z);
        highlight.transform.position = new Vector3(Mathf.Floor(transform.position.x), 0.1f, Mathf.Floor(transform.position.z));
        highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        highlight.GetComponent<Collider>().isTrigger = true;
        highlight.GetComponent<Renderer>().enabled = false;
    }

    public abstract void die();

    //do we still need these functions
    public abstract void activate();  
    public abstract void deactivate();
}
