using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    public GameObject cubePrefab; // K�p prefab'�n� buradan atay�n
    private GameObject spawnedCube; // Olu�turulan k�p i�in referans

    private void OnTriggerEnter(Collider other)
    {
        // E�er nesne "Man" etiketine sahipse
        if (other.CompareTag("Collectable"))
        {
            // Kar��la��lan nesneyi yok et
            Destroy(other.gameObject);

            // Kar��la��lan nesnenin SkinnedMeshRenderer'�n� kontrol et
            SkinnedMeshRenderer otherSkinnedMeshRenderer = other.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer playerSkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

            if (otherSkinnedMeshRenderer != null && playerSkinnedMeshRenderer != null)
            {
                // Karakter ve nesne ayn� SkinnedMeshRenderer'a sahipse
                if (otherSkinnedMeshRenderer.sharedMesh == playerSkinnedMeshRenderer.sharedMesh)
                {
                    // Arkada bir k�p olu�tur
                    if (spawnedCube == null)
                    {
                        Vector3 spawnPosition = transform.position - transform.forward; // Karakterin arkas�nda
                        spawnedCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                    }
                }
                else
                {
                    // Arkadaki k�p� yok et
                    if (spawnedCube != null)
                    {
                        Destroy(spawnedCube);
                        spawnedCube = null;
                    }
                }
            }
        }
    }
}
