using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    public GameObject cubePrefab; // Küp prefab'ýný buradan atayýn
    private GameObject spawnedCube; // Oluþturulan küp için referans

    private void OnTriggerEnter(Collider other)
    {
        // Eðer nesne "Man" etiketine sahipse
        if (other.CompareTag("Collectable"))
        {
            // Karþýlaþýlan nesneyi yok et
            Destroy(other.gameObject);

            // Karþýlaþýlan nesnenin SkinnedMeshRenderer'ýný kontrol et
            SkinnedMeshRenderer otherSkinnedMeshRenderer = other.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer playerSkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

            if (otherSkinnedMeshRenderer != null && playerSkinnedMeshRenderer != null)
            {
                // Karakter ve nesne ayný SkinnedMeshRenderer'a sahipse
                if (otherSkinnedMeshRenderer.sharedMesh == playerSkinnedMeshRenderer.sharedMesh)
                {
                    // Arkada bir küp oluþtur
                    if (spawnedCube == null)
                    {
                        Vector3 spawnPosition = transform.position - transform.forward; // Karakterin arkasýnda
                        spawnedCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                    }
                }
                else
                {
                    // Arkadaki küpü yok et
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
