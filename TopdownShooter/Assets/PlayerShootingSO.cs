using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerShootSO_", menuName = "Player/PlayerShootData")]
public class PlayerShootingSO : ScriptableObject
{
    public Material raycastMaterial;
    public Transform normalProjectilePrefab;
    public float projectileSpeed;
    public float shootingDelay;
}