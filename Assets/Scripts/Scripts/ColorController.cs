using Enums;
using UnityEngine;

namespace Controllers
{
    public class ColorController : MonoBehaviour
    {
        public ColorTypes ColorType;

        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Material[] materials; // Malzemeleri burada saklayýn

        private void Awake()
        {
            ChangeAreaColor(ColorType);
        }

        public void ChangeAreaColor(ColorTypes _colorType)
        {
            // ColorTypes enum deðerine göre malzemeyi seçin ve atayýn
            Material selectedMaterial = materials[(int)_colorType];
            if (selectedMaterial != null)
            {
                meshRenderer.material = selectedMaterial;
            }
        }
    }
}
