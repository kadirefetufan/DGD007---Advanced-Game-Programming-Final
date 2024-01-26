using Enums;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public ColorTypes ColorType;
    public string targetTag = "GameTag"; // De�i�tirilecek materyalin tag'�

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material[] materials; // Malzemeleri burada saklay�n

    // Materyal ve tag'lar� e�le�tirmek i�in bir s�zl�k
    private Dictionary<Material, string> materialTags = new Dictionary<Material, string>();

    private void Awake()
    {
        ChangeAreaColor(ColorType);
        InitializeMaterialTags();
    }

    // Materyal ve tag e�le�tirmelerini ba�latmak i�in bir metod
    private void InitializeMaterialTags()
    {
        foreach (Material mat in materials)
        {
            // Burada her materyali bir tag ile e�le�tirin
            // �rnek: materialTags[mat] = "Baz�Tag";
           materialTags[mat] = "Baz�Tag";
        }
    }

    public void ChangeAreaColor(ColorTypes _colorType)
    {
        // _colorType de�erinin materials dizisinin boyutu i�inde oldu�unu kontrol edin
        if ((int)_colorType >= 0 && (int)_colorType < materials.Length)
        {
            Material selectedMaterial = materials[(int)_colorType];
            if (selectedMaterial != null)
            {
                meshRenderer.material = selectedMaterial;
            }
        }
        else
        {
            Debug.LogError("ColorType index is out of range. Please check the materials array and ColorType enum.");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer otherMeshRenderer = other.GetComponent<MeshRenderer>();
        if (otherMeshRenderer != null)
        {
            // Ge�en nesnenin materyallerini kontrol et
            foreach (Material mat in otherMeshRenderer.materials)
            {
                // E�er materyal belirli bir tag ile e�le�tirilmi�se, onu de�i�tir
                if (materialTags.ContainsKey(mat) && materialTags[mat] == targetTag)
                {
                    mat.CopyPropertiesFromMaterial(meshRenderer.material);
                }
            }
        }
    }
}
