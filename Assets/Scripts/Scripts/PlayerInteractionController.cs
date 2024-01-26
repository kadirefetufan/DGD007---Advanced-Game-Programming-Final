using UnityEngine;
using System.Collections.Generic;

public class PlayerInteractionController : MonoBehaviour
{
    public GameObject cubePrefab; // Küp prefab'ýný buradan atayýn
    private List<GameObject> spawnedCubes = new List<GameObject>(); // Oluþturulan küplerin listesi

    private void OnTriggerEnter(Collider other)
    {
        // Etkileþime girilen nesneyi yok et
        

        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            // Collectable ile etkileþime girildiðinde yeni bir küp oluþtur
            Vector3 spawnPosition = spawnedCubes.Count > 0
                ? spawnedCubes[spawnedCubes.Count - 1].transform.position - transform.forward
                : transform.position - transform.forward;

            GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            spawnedCubes.Add(newCube);
        }
        else if (other.CompareTag("Collected") && spawnedCubes.Count > 0)
        {
            Destroy(other.gameObject);
            // Collected ile etkileþime girildiðinde son küpü yok et
            GameObject lastCube = spawnedCubes[spawnedCubes.Count - 1];
            spawnedCubes.Remove(lastCube);
            Destroy(lastCube);
        }
    }
}
