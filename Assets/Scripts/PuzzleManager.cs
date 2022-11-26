using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private List<PuzzleSlot> slotPrefabs;

    [SerializeField]
    private PuzzlePiece piecePrefabs;

    [SerializeField]
    private Transform slotParent;

    [SerializeField]
    private Transform pieceParent;

    private void Start() 
    {
        Spawn();
    }

    private void Spawn()
    {
        var randomSet = slotPrefabs.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnedSlot = Instantiate(randomSet[i],slotParent.GetChild(i).position,Quaternion.identity);
            var spawnedPiece = Instantiate(piecePrefabs,pieceParent.GetChild(i).position,Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
        }
    }
}
