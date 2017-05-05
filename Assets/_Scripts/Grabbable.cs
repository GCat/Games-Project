using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Grabbable : MonoBehaviour
{

    protected List<Renderer> child_materials;
    protected Shader[] original_materials;
    protected bool allowOutline = true;
    private Shader outlineShader;
    //function to be called when grabbed by hand
    public abstract void grab();

    //function to be called when released from hand
    public abstract void release(Vector3 vel);

    public void setGrabbable(bool grabbable)
    {
        allowOutline = grabbable;
    }

    private void init()
    {
        outlineShader = Shader.Find("Toon/Basic Outline");
        child_materials = new List<Renderer>(GetComponentsInChildren<Renderer>(false));
        ParticleSystemRenderer[] ps = GetComponentsInChildren<ParticleSystemRenderer>(false);
        foreach (ParticleSystemRenderer p in ps)
        {
            child_materials.Remove(p);
        }
        List<Renderer> newChildMaterials = new List<Renderer>();
        foreach (Renderer r in child_materials)
        {
            if (r.gameObject.tag != "Iron")
            {
                newChildMaterials.Add(r);
            }
        }
        child_materials = newChildMaterials;


        original_materials = new Shader[child_materials.Count];
        for (int i = 0; i < child_materials.Count; i++)
        {
            original_materials[i] = child_materials[i].material.shader;
        }
    }
    public void setOutline()
    {

        if (outlineShader == null)
        {
            init();
        }
        if (!allowOutline)
        {
            return;
        }
        for (int i = 0; i < child_materials.Count; i++)
        {
            try
            {
                if (child_materials[i] != null && child_materials[i].material.shader != null)
                {
                    child_materials[i].material.shader = outlineShader;
                    child_materials[i].material.SetColor("_OutlineColor", Color.green);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

    public void removeOutline()
    {
        if (outlineShader == null)
        {
            init();
        }
        for (int i = 0; i < child_materials.Count; i++)
        {
            if (child_materials != null && child_materials[i] != null && original_materials[i] != null)
            {
                child_materials[i].material.shader = original_materials[i];
            }

        }
    }
    protected void setWarning()
    {
        if (outlineShader == null)
        {
            init();
        }
        for (int i = 0; i < child_materials.Count; i++)
        {
            child_materials[i].material.shader = outlineShader;
            child_materials[i].material.SetColor("_OutlineColor", Color.red);
        }

    }

    protected void showStartOutline()
    {
        if (outlineShader == null)
        {
            init();
        }
        for (int i = 0; i < child_materials.Count; i++)
        {
            child_materials[i].material.shader = outlineShader;
            child_materials[i].material.SetColor("_OutlineColor", Color.yellow);
        }
    }

}
