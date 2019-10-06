using UnityEngine;

namespace Graphics {

    public class CharacterSpriteLoader : MonoBehaviour {

        [SerializeField]
        private SpriteRenderer body = null;
        [SerializeField]
        private SpriteRenderer eye = null;
        [SerializeField]
        private SpriteRenderer pants = null;
        [SerializeField]
        private SpriteRenderer clothes = null;
        [SerializeField]
        private SpriteRenderer hair = null;

        public void Load(CharacterSpriteParameters parameters) {
            body.sprite = SpritesHolder.instance.body[parameters.body];
            body.color = parameters.skinColor;
            eye.sprite = SpritesHolder.instance.eye[parameters.eye];
            pants.sprite = SpritesHolder.instance.pants[parameters.pants];
            clothes.sprite = SpritesHolder.instance.clothes[parameters.clothes];
            clothes.materials[1].SetFloat("_HueShift", parameters.clothHue);
            hair.sprite = SpritesHolder.instance.hair[parameters.hair];
            hair.color = parameters.hairColor;
        }

        void Start() {
            Material material = new Material(Shader.Find("Custom/HSVShader"));
            clothes.materials = new Material[]{ clothes.material, material };
            Load(SpritesHolder.instance.RandomCharacterSet());
        }

    }

}