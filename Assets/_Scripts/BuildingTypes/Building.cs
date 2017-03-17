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
    GameObject resourceGainText;
    public bool bought = false;

    public int faithCost;
    protected Vector3 boxSize;
    public GameObject highlight;
    public bool canBeGrabbed = true;
    protected Renderer[] child_materials;
    protected Shader outlineShader;
    private GameObject ExplosionEffect;


    public abstract bool canBuy();
    public abstract void changeTextColour(Color colour);

    public void decrementHealth(float damage)
    {
        if (!healthBar.activeSelf) healthBar.SetActive(true);
        health -= damage;
        float scale = (health / totalHealth);
        float buildingScale = gameObject.transform.localScale.x;
        healthBar.transform.localScale = new Vector3(1.0f / buildingScale, 10.0f * scale / buildingScale, 1.0f / buildingScale);
        if (scale != 0) healthBar.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f - scale, scale, 0));

        if (health <= 0)
        {
            GameObject explosion = GameObject.Instantiate(ExplosionEffect);
            explosion.transform.position = transform.position;
            Destroy(explosion, 3.0f);
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
        resourceGainText = createInfoText("ResourceGainTablet");
        boxSize = GetComponent<BoxCollider>().bounds.size / 2;
        boxSize.y = 1f;
        child_materials = GetComponentsInChildren<Renderer>(false);
        outlineShader = Shader.Find("Toon/Basic Outline");
        ExplosionEffect = Resources.Load("Explosion") as GameObject;
        if(ExplosionEffect != null)
        {
            Debug.Log("Effect loaded");
        }
    }

    //return true if within bounds & not above another building
    public bool canPlace()
    {

        float x = transform.position.x;
        float z = transform.position.z;

        int layerMask = (1 << 10 | 1<<15);
        if (resourceCounter.withinBounds(transform.position))
        {
            GetComponent<Collider>().enabled = true;
            if (Physics.CheckBox(new Vector3(x, 0, z), boxSize, Quaternion.LookRotation(Vector3.forward), layerMask))
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {

            if ((resourceCounter.hasGameStarted() && (faithCost <= resourceCounter.getFaith())) || gameObject.tag == "Temple")
            {
                setOutline();
                changeTextColour(Color.green);
            }
            else
            {
                setWarning();
                changeTextColour(Color.red);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            removeOutline();
            changeTextColour(Color.white);
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
        highlightDestroy();
    }

    public IEnumerator ResourceGainText(int value,string resource)
    {
        Vector3 cameraPos = GameObject.FindWithTag("MainCamera").transform.position;
        GameObject resourceText = GameObject.Instantiate(resourceGainText,resourceGainText.transform) as GameObject;
        resourceText.transform.parent = gameObject.transform;
        Vector2 randPos = UnityEngine.Random.insideUnitCircle*5.0f;
        resourceText.transform.Translate(new Vector3(randPos.x,-2.0f,randPos.y*2.0f));
        Vector3 startLocation = resourceText.transform.position;
        cameraPos.y = startLocation.y;
        resourceText.transform.LookAt(2*startLocation - cameraPos);
        resourceText.transform.Rotate(new Vector3(0, 90, 0));
        //resourceText.GetComponent<TextMesh>().text = "+" + value.ToString() + " " + resource;
        resourceText.GetComponent<ResourceGainTablet>().setText("+" + value.ToString());
        Color c;
        resourceText.SetActive(true);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            resourceText.GetComponent<ResourceGainTablet>().setAlpha(f);
            resourceText.transform.Translate(new Vector3(0, 0.1f, 0));
            yield return null;
        }
        resourceText.SetActive(false);
        GameObject.Destroy(resourceText);
    }

    public void setInfoText(GameObject infoText, int faithCost)
    {
        infoText.GetComponent<TextMesh>().text = "  " + faithCost.ToString();
        infoText.SetActive(true);
    }

    public void createHealthBar()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        healthBar = GameObject.Instantiate(Resources.Load("HealthBar")) as GameObject;
        healthBar.transform.position = gameObject.GetComponent<Collider>().transform.position;
        healthBar.transform.Translate(new Vector3(0, actualSize.y*1.5f, 0));
        healthBar.transform.eulerAngles = new Vector3(0.0f, 90.0f, 90.0f);
        healthBar.transform.SetParent(gameObject.transform);
        healthBar.SetActive(false);
    }

    public GameObject createInfoText(string prefab)
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        GameObject newText = GameObject.Instantiate(Resources.Load(prefab)) as GameObject;
        newText.transform.position = gameObject.transform.position;
        newText.transform.localScale *= 2;
        newText.transform.Translate(new Vector3(0, actualSize.y * 1.3f, 0));
        newText.transform.localRotation = gameObject.transform.localRotation;
        //newText.transform.Rotate(new Vector3(0, -90, 0));
        newText.transform.SetParent(gameObject.transform);
        newText.SetActive(false);
        return newText;
    }

    public void highlightCheck()
    {
        if (resourceCounter.aboveBoard(transform.position))
        {
            if (transform.position.y < 0.1f)
            {
                highlightDestroy();
                return;
            }
            highlight.GetComponent<Renderer>().enabled = true;
            highlight.transform.position = new Vector3(transform.position.x, 0.1f,transform.position.z);
            float yRot = gameObject.transform.eulerAngles.y;
            if ((yRot > 45 && yRot < 135) || (yRot > -135 && yRot < -45))
            {
                highlight.transform.rotation = Quaternion.LookRotation(Vector3.right);

            }
            else
            {
                highlight.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            }
            int layerMask = 1 << 10 | 1<<15;
            if (Physics.CheckBox(new Vector3(Mathf.Floor(transform.position.x), 0, Mathf.Floor(transform.position.z)), boxSize,gameObject.transform.rotation, layerMask))
                highlight.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            else
                highlight.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
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
        highlight.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        highlight.transform.localScale = new Vector3(boxSize.x*2.0f, 0.1f, boxSize.z*2.0f);
        highlight.transform.position = new Vector3(transform.position.x , 0.1f, transform.position.z);
        highlight.transform.rotation = transform.rotation;

        highlight.GetComponent<Collider>().isTrigger = true;
        highlight.GetComponent<Renderer>().enabled = false;
    }

    public abstract void die();

    //do we still need these functions
    public abstract void activate();  
    public abstract void deactivate();
}
