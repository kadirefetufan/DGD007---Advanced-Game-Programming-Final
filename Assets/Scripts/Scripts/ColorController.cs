using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Material newColorMaterial; // Karakterin deðiþeceði yeni renk

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
      
        Debug.Log("Tag of the object: " + other.tag); 

        if (other.CompareTag("Portal")) // Etiketi burada kontrol ediyoruz
        {
            Debug.Log("Correct tag found, changing color.");
            SkinnedMeshRenderer skinnedMeshRenderer = other.GetComponent<SkinnedMeshRenderer>();
            if (skinnedMeshRenderer != null)
            {
                Debug.Log("SkinnedMeshRenderer found, changing material.");
                skinnedMeshRenderer.material = newColorMaterial; // Burada malzemeyi deðiþtiriyoruz
            }
            else
            {
                Debug.Log("SkinnedMeshRenderer not found on the player.");
            }
        }
        else
        {
            Debug.Log("Tag not matched.");
        }
    }



}
