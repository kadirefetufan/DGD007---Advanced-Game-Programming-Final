using UnityEngine;
using System.Collections.Generic;

public class PlayerInteractionController : MonoBehaviour
{
    public GameObject cubePrefab; // K�p prefab'�n� buradan atay�n
    private List<GameObject> spawnedCubes = new List<GameObject>(); // Olu�turulan k�plerin listesi

    private void OnTriggerEnter(Collider other)
    {
        // Etkile�ime girilen nesneyi yok et
        

        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            // Collectable ile etkile�ime girildi�inde yeni bir k�p olu�tur
            Vector3 spawnPosition = spawnedCubes.Count > 0
                ? spawnedCubes[spawnedCubes.Count - 1].transform.position - transform.forward
                : transform.position - transform.forward;

            GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            spawnedCubes.Add(newCube);
        }
        else if (other.CompareTag("Collected") && spawnedCubes.Count > 0)
        {
            Destroy(other.gameObject);
            // Collected ile etkile�ime girildi�inde son k�p� yok et
            GameObject lastCube = spawnedCubes[spawnedCubes.Count - 1];
            spawnedCubes.Remove(lastCube);
            Destroy(lastCube);
        }
    }
}
