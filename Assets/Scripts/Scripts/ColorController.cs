using Enums;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public ColorTypes ColorType;
    public string targetTag = "GameTag"; // Deðiþtirilecek materyalin tag'ý

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material[] materials; // Malzemeleri burada saklayýn

    // Materyal ve tag'larý eþleþtirmek için bir sözlük
    private Dictionary<Material, string> materialTags = new Dictionary<Material, string>();

    private void Awake()
    {
        ChangeAreaColor(ColorType);
        InitializeMaterialTags();
    }

    // Materyal ve tag eþleþtirmelerini baþlatmak için bir metod
    private void InitializeMaterialTags()
    {
        foreach (Material mat in materials)
        {
            // Burada her materyali bir tag ile eþleþtirin
            // Örnek: materialTags[mat] = "BazýTag";
           materialTags[mat] = "BazýTag";
        }
    }

    public void ChangeAreaColor(ColorTypes _colorType)
    {
        // _colorType deðerinin materials dizisinin boyutu içinde olduðunu kontrol edin
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
            // Geçen nesnenin materyallerini kontrol et
            foreach (Material mat in otherMeshRenderer.materials)
            {
                // Eðer materyal belirli bir tag ile eþleþtirilmiþse, onu deðiþtir
                if (materialTags.ContainsKey(mat) && materialTags[mat] == targetTag)
                {
                    mat.CopyPropertiesFromMaterial(meshRenderer.material);
                }
            }
        }
    }
}
