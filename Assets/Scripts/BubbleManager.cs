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
                Debug.Log(prefab.name);
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
        private Bubble _player;

        //nlogn Access To Any Ally, Enemy, Or Status Effect Gameobjects
        private Dictionary<string, Bubble> _enemy_units = new Dictionary<string, Bubble>();
        private Dictionary<string, Bubble> _friend_units = new Dictionary<string, Bubble>();
        private Dictionary<string, StatusEffect> _status_effects = new Dictionary<string, StatusEffect>();

        private PrefabEnum _enemy_prefab_enum;
        private PrefabEnum _ally_prefab_enum;
        private PrefabEnum _status_effect_enum;

        //Prefab Lists For Enemies, Allies, And Status Effects
        public List<GameObject> enemy_prefabs;
        public List<GameObject> ally_prefabs;
        public List<GameObject> effect_prefabs;
        
        void Start()
        {
            _enemy_prefab_enum = new PrefabEnum(enemy_prefabs);
            _ally_prefab_enum = new PrefabEnum(ally_prefabs);
            _status_effect_enum = new PrefabEnum(effect_prefabs);
        }

        void Update()
        {

        }

        private void GenerateEnemyBubble(Vector3 position, Quaternion rotation)
        {
            
        }

        private void GenerateAllyBubble(Vector3 position)
        {

        }

        private void GenerateStatusEffect(Vector3 position, System.Action<Bubble> effect_cb)
        {

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