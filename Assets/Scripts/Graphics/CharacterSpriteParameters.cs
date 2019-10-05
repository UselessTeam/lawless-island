using UnityEngine;

namespace Graphics {

    public struct CharacterSpriteParameters {
        public int body;
        public int eye;
        public int pants;
        public int clothes;
        public int hair;

        public Color skinColor;
        public float clothHue;
        public Color hairColor;

        public CharacterSpriteParameters(int body, int eye, int pants, int clothes, int hair, Color skinColor, float clothHue, Color hairColor) {
            this.body = body;
            this.eye = eye;
            this.pants = pants;
            this.clothes = clothes;
            this.hair = hair;

            this.skinColor = skinColor;
            this.clothHue = clothHue;
            this.hairColor = hairColor;
        }
    }

}