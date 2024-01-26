using UnityEngine;

namespace Controllers
{
    public class ColorController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Material newMaterial; // Elle atayabileceðiniz material

        private void Awake()
        {
            ChangeMaterial(newMaterial);
        }

        public void ChangeMaterial(Material material)
        {
            if (material != null && meshRenderer != null)
            {
                meshRenderer.material = material;
            }
        }
    }
}
