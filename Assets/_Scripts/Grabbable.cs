using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Grabbable : MonoBehaviour {

    protected Renderer[] child_materials;
    protected Shader[] original_materials;
    private Shader outlineShader;

    //function to be called when grabbed by hand
    public abstract void grab();

    //function to be called when released from hand
    public abstract void release(Vector3 vel);


    private void init()
    {
        outlineShader = Shader.Find("Toon/Basic Outline");
        child_materials = GetComponentsInChildren<Renderer>(false);
        original_materials = new Shader[child_materials.Length];
        for (int i = 0; i < child_materials.Length; i++)
        {
            original_materials[i] = child_materials[i].material.shader;
        }
    }

    public void setOutline()
    {
        if(outlineShader == null)
        {
            init();
        }
        for (int i = 0; i < child_materials.Length; i++)
        {
            child_materials[i].material.shader = outlineShader;
            child_materials[i].material.SetColor("_OutlineColor", Color.green);
        }
    }

    public void removeOutline()
    {
        if (outlineShader == null)
        {
            init();
        }
        for (int i = 0; i < child_materials.Length; i++)
        {
            child_materials[i].material.shader = original_materials[i];

        }
    }
    protected void setWarning()
    {
        if (outlineShader == null)
        {
            init();
        }
        for (int i = 0; i < child_materials.Length; i++)
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
        for (int i = 0; i < child_materials.Length; i++)
        {
            child_materials[i].material.shader = outlineShader;
            child_materials[i].material.SetColor("_OutlineColor", Color.yellow);
        }
    }

}
