using UnityEngine;

namespace Graphics {

    public class CharacterSpritesHolder : Singleton<CharacterSpritesHolder> {
        public Sprite[] body;
        public Sprite[] eye;
        public Sprite[] pants;
        public Sprite[] clothes;
        public Sprite[] hair;

        private int RandomId(Sprite[] sprites) {
            return Random.Range(0, sprites.Length);
        }

        private Color RandomColor() {
            return Color.white;
        }

        private float RandomHue() {
            return Random.Range(-180f, 180f);
        }

        public CharacterSpriteParameters RandomSet() {
            return new CharacterSpriteParameters(RandomId(body),
                                                 RandomId(eye),
                                                 RandomId(pants),
                                                 RandomId(clothes),
                                                 RandomId(hair),
                                                 RandomColor(),
                                                 RandomHue(),
                                                 RandomColor());
        }
    }
}
