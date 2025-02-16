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

    public class EntityManager : MonoBehaviour
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
        public GameObject player_prefab;
        
        void Start()
        {
            _enemy_prefab_enum = new PrefabEnum(enemy_prefabs);
            _ally_prefab_enum = new PrefabEnum(ally_prefabs);
            _status_effect_enum = new PrefabEnum(status_effect_prefabs);
        }

        void Update()
        {

        }

        public GameObject GetPlayer() //TODO: Currently One Player, but Can Have Parameter For Player Number For Multiple Players
        {
            return _player;
        }

        public GameObject GetEnemy(string name)
        {
            GameObject enemy = null;

            if(_enemy_units.ContainsKey(name))
            {
                enemy = _enemy_units[name];
            }

            return enemy;
        }

        public GameObject GetAlly(string name)
        {
            GameObject ally = null;

            if(_ally_units.ContainsKey(name))
            {
                ally = _ally_units[name];
            }

            return ally;
        }

        public GameObject GetStatusEffect(string name)
        {
            GameObject status_effect = null;

            if(_status_effects.ContainsKey(name))
            {
                status_effect = _status_effects[name];
            }

            return status_effect;
        }

        private void GeneratePlayer(Vector3 position, Quaternion rotation)
        {
            _player = Instantiate(player_prefab, position, rotation);
        }

        private void GenerateEnemy(string enemy_prefab_type, Vector3 position, Quaternion rotation)
        {
            GameObject enemy = Instantiate(enemy_prefabs[_enemy_prefab_enum[enemy_prefab_type]], position, rotation);
            _enemy_units.Add(enemy.name, enemy);
        }

        private void GenerateAlly(string ally_prefab_type, Vector3 position, Quaternion rotation)
        {
            GameObject ally = Instantiate(ally_prefabs[_ally_prefab_enum[ally_prefab_type]], position, rotation);
            _ally_units.Add(ally.name, ally);
        }

        private void GenerateStatusEffect(string status_effect_prefab_type, Vector3 position, Quaternion rotation, System.Action<Bubble> effect_cb)
        {
            GameObject status_effect = Instantiate(status_effect_prefabs[_status_effect_enum[status_effect_prefab_type]], position, rotation);
            _status_effects.Add(status_effect.name, status_effect);
        }

        private bool DestroyPlayer()
        {
            Destroy(_player);
            _player = null;
            return true;
        }

        private bool DestroyEnemy(string name)
        {
            bool destroyed = false;

            if(_enemy_units.ContainsKey(name))
            {
                GameObject enemy;
                _enemy_units.Remove(name, out enemy);
                Destroy(enemy);
                destroyed = true;
            }

            return destroyed;
        }

        private bool DestroyAlly(string name)
        {
            bool destroyed = false;

            if(_ally_units.ContainsKey(name))
            {
                GameObject ally;
                _ally_units.Remove(name, out ally);
                Destroy(ally);
                destroyed = true;
            }

            return destroyed;
        }

        private bool DestroyStatusEffect(string name)
        {
            bool destroyed = false;

            if(_status_effects.ContainsKey(name))
            {
                GameObject status_effect;
                _status_effects.Remove(name, out status_effect);
                Destroy(status_effect);
                destroyed = true;
            }

            return destroyed;
        }


    }
}