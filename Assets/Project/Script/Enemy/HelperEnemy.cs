using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    public void TakePlayer() => _enemy.TakePlayer();
}
