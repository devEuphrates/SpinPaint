using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Painting Holder", menuName = "Drawing/Painting Holder")]
public class PaintHolderSO : ScriptableObject
{
    [SerializeField] List<PaintingSO> _paintings = new List<PaintingSO>();

    public PaintingSO GetPainting(int index, bool repeat = true)
    {
        bool overflow = index > _paintings.Count - 1;
        index = repeat ? index % _paintings.Count : overflow ? Random.Range(1, _paintings.Count) : index;
        return _paintings[index];
    }
}
