using UnityEngine;
using System.Collections;

public class AnimatedTextures : MonoBehaviour {

    public Texture[] textures;
    public float changeInterval = 0.033F;
    public Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        if (textures.Length == 0)
            return;

        int index = (int)(Time.time / changeInterval);
        index = index % textures.Length;
        rend.material.mainTexture = textures[index];
    }

}
