using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPieces;
    public Transform player;
    public float pieceLength = 100f;

    void Start()
    {
        if (roadPieces.Length > 0)
        {
            pieceLength = roadPieces[0].GetComponent<Renderer>().bounds.size.z;
        }
    }

    void Update()
    {
        foreach (GameObject road in roadPieces)
        {
            if (player.position.z > road.transform.position.z + (pieceLength * 0.6f))
            {
                float highestZ = GetHighestZ();
                road.transform.position = new Vector3(
                    road.transform.position.x,
                    road.transform.position.y,
                    highestZ + pieceLength
                );
            }
        }
    }
    float GetHighestZ()
    {
        float highestZ = float.MinValue;
        foreach (GameObject road in roadPieces)
        {
            if (road.transform.position.z > highestZ)
                highestZ = road.transform.position.z;
        }
        return highestZ;
    }
}
