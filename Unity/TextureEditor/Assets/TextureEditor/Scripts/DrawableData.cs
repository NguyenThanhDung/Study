using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextureEditor
{
    [CreateAssetMenu]
    public class DrawableData : ScriptableObject
    {
        public List<Texture2D> textures;
    }
}
