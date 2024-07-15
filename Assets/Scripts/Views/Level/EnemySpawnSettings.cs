using System;
using Models;
using Models.Entity;
using UnityEngine;

namespace Views.Level
{
    [Serializable]
    public class EnemySpawnSettings
    {
        public Transform SpawnTransform;
        public EnemyType EnemyType;
    }
}