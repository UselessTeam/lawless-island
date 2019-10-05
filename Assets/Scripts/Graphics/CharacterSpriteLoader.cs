using UnityEngine;

namespace Graphics {

    public class CharacterSpriteLoader : MonoBehaviour {

        [SerializeField]
        private SpriteRenderer body;
        [SerializeField]
        private SpriteRenderer eye;
        [SerializeField]
        private SpriteRenderer pants;
        [SerializeField]
        private SpriteRenderer clothes;
        [SerializeField]
        private SpriteRenderer hair;

        public void Load(CharacterSpriteParameters parameters) {
            body.sprite = CharacterSpritesHolder.instance.body[parameters.body];
            body.color = parameters.skinColor;
            eye.sprite = CharacterSpritesHolder.instance.eye[parameters.eye];
            pants.sprite = CharacterSpritesHolder.instance.pants[parameters.pants];
            clothes.sprite = CharacterSpritesHolder.instance.clothes[parameters.clothes];
            clothes.materials[1].SetFloat("_HueShift", parameters.clothHue);
            hair.sprite = CharacterSpritesHolder.instance.hair[parameters.hair];
            hair.color = parameters.hairColor;
        }

        void Start() {
            Material material = new Material(Shader.Find("Custom/HSVShader"));
            clothes.materials = new Material[]{ clothes.material, material };
            Load(CharacterSpritesHolder.instance.RandomSet());
        }

    }

}