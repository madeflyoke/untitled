using System;
using System.Collections;
using System.Collections.Generic;
using Units.Base;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
   [SerializeField] private List<Unit> _enemies;

   private void Start()
   {
       _enemies.ForEach(x=>
       {
           Instantiate(x, transform);
       });
   }
}
