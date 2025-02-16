using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace LGS 
{
    public class PrefabEnum
    {
        private Dictionary<string, int> _prefabs = new Dictionary<string, int>();
        private int item_count = 0;

        public PrefabEnum(List<GameObject> prefabs)
        {
            foreach(GameObject prefab in prefabs)
            {
                _prefabs.Add(prefab.name, item_count);
                item_count += 1;
            }
        }

        public int this[string name]
        {
            get => _prefabs[name];
        }
    }

    public class BubbleManager : MonoBehaviour
    {
        private GameObject _player;

        //nlogn Access To Any Ally, Enemy, Or Status Effect Gameobjects
        private Dictionary<string, GameObject> _enemy_units = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> _ally_units = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> _status_effects = new Dictionary<string, GameObject>();
        //////////

        private PrefabEnum _enemy_prefab_enum;
        private PrefabEnum _ally_prefab_enum;
        private PrefabEnum _status_effect_enum;

        //Prefab Lists For Enemies, Allies, And Status Effects
        public List<GameObject> enemy_prefabs;
        public List<GameObject> ally_prefabs;
        public List<GameObject> status_effect_prefabs;
        
        void Start()
        {
            _enemy_prefab_enum = new PrefabEnum(enemy_prefabs);
            _ally_prefab_enum = new PrefabEnum(ally_prefabs);
            _status_effect_enum = new PrefabEnum(status_effect_prefabs);

            Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
            GenerateEnemyBubble("Normal_Bubbles", spawnPos, Quaternion.identity);
        }

        void Update()
        {

        }

        private void GenerateEnemyBubble(string enemy_prefab_type, Vector3 position, Quaternion rotation)
        {
            GameObject enemy = Instantiate(enemy_prefabs[_enemy_prefab_enum[enemy_prefab_type]], position, rotation);
            _enemy_units.Add(enemy.name, enemy);
        }

        private void GenerateAllyBubble(string ally_prefab_type, Vector3 position, Quaternion rotation)
        {
            GameObject ally = Instantiate(ally_prefabs[_ally_prefab_enum[ally_prefab_type]], position, rotation);
            _ally_units.Add(ally.name, ally);
        }

        private void GenerateStatusEffect(string status_effect_prefab_type, Vector3 position, Quaternion rotation, System.Action<Bubble> effect_cb)
        {
            GameObject status_effect = Instantiate(status_effect_prefabs[_status_effect_enum[status_effect_prefab_type]], position, rotation);
            _status_effects.Add(status_effect.name, status_effect);
        }

        private bool DestroyEnemyBubble(string name)
        {
            bool destroyed = false;

            return destroyed;
        }

        private bool DestroyAllyBubble(string name)
        {
            bool destroyed = false;

            return destroyed;
        }

        private bool DestroyStatusEffect(string name)
        {
            bool destroyed = false;

            return destroyed;
        }


    }
}