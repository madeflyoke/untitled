using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Factories;
using Units.Base;
using Units.Enums;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
   [SerializeField] private List<UnitClass> _enemies;
   [SerializeField] private UnitsFactory _unitsFactory;

   [SerializeField] private List<Transform> _enemiesPoints;
   [SerializeField] private List<Transform> _alliesPoints;
   
   private void Start()
   {
      for (int i = 0; i < _enemiesPoints.Count; i++)
      {
         if (_enemies.Count-1>=i)
         {
            var pointTr = _enemiesPoints[i];
            var unitClass = _enemies[i];

            _unitsFactory.CreateUnit(unitClass, pointTr.position, pointTr.rotation, pointTr);
         }
      }
   }

   private void Update()
   {
      
   }
}
