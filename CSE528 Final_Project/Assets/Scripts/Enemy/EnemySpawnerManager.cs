using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveAttribute
{
    public GameObject enemy;
    public int count;
    public float CD_Timer;
}

public class EnemySpawnerManager : MonoBehaviour
{
    public static int currentEnemyCount = 0;
    
    public WaveAttribute[] waveAttribute;
    public float wave_CD_Time = 6;
    public int moneyPerRound = 250;
    
    public Transform startPoint;
    
    void Start () 
    {
        StartCoroutine (CreateEnemy ());
        
    }

    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < waveAttribute.Length; i++)
        {
            var wave = waveAttribute[i];
            HUDHealthBar.Instance.roundText.text = "Round " + (i + 1);
            for (int j = 0; j < wave.count; j++)
            {
                Instantiate(wave.enemy, startPoint.position, Quaternion.identity);
                currentEnemyCount++;

                if (j != wave.count - 1)
                {
                    yield return new WaitForSeconds(wave.CD_Timer);
                }
            }
            
            while (currentEnemyCount > 0)
            {
                yield return 0;
            }

            // get money when wave ends
            PlayerStats.Money += moneyPerRound;

            yield return new WaitForSeconds(wave_CD_Time);
        }
        HUDHealthBar.Instance.successPanel.SetActive(true);
    }
}
