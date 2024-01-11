using System;
using Unity.Mathematics;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData MovementData;
        public PlayerMeshData MeshData;
    }

    [Serializable]
    public struct PlayerMeshData
    {
        public float ScaleCounter;
    }

    [Serializable]
    public struct PlayerMovementData
    {
        public float ForwardSpeed;
        public float SidewaysSpeed;
        public float2 ForwardForceCounter;
    }
}