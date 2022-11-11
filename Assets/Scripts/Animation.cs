using UnityEngine;
using System.Collections;

public class BlendShapeExample : MonoBehaviour
{
    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    int playindex = 0;


    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShapeCount = skinnedMesh.blendShapeCount;
    }

    void Update()
    {
        if (playindex > 0)
            skinnedMeshRenderer.SetBlendShapeWeight(playindex - 1, 0f);
        if (playindex == 0)
            skinnedMeshRenderer.SetBlendShapeWeight(blendShapeCount -1, 0f);

        skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
        playindex++;
        if (playindex > blendShapeCount - 1)
            playindex = 0;
    }
}
