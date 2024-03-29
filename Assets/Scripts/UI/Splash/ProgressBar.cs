using UnityEngine;


namespace Madyasiwi.Astrajingga.UI.Splash {

    public class ProgressBar : MonoBehaviour {

        [Range(0.0f, 1.0f)]
        public float fraction;

        private MaterialPropertyBlock propertyBlock;
        private CanvasRenderer renderer_;
        private Material material;


        void Awake() {
            propertyBlock = new MaterialPropertyBlock();
            renderer_ = GetComponent<CanvasRenderer>();
        }


        void Start() {
            material = null;
        }


        void Update() {
            if (!material) {
                material = renderer_.GetMaterial();
            }
            if (material) {
                material.SetFloat("_Fraction", fraction);
            }
        }
    }
}