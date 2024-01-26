using Enums;
using UnityEngine;

namespace Controllers
{
    public class ColorController : MonoBehaviour
    {
        public ColorTypes ColorType;

        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Material[] materials; // Malzemeleri burada saklay�n

        private void Awake()
        {
            ChangeAreaColor(ColorType);
        }

        public void ChangeAreaColor(ColorTypes _colorType)
        {
            // ColorTypes enum de�erine g�re malzemeyi se�in ve atay�n
            Material selectedMaterial = materials[(int)_colorType];
            if (selectedMaterial != null)
            {
                meshRenderer.material = selectedMaterial;
            }
        }
    }
}
