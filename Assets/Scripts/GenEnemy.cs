using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenEnemy : MonoBehaviour
{

    public List<GameObject> enemy_normal_line;
    public List<GameObject> enemy_normal_curve;
    public List<GameObject> enemy_hard;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameSetting._gameManager;

        setupLevel(Data.instance.enemy_normal_line, enemy_normal_line);
        setupLevel(Data.instance.enemy_normal_curve, enemy_normal_curve);
        setupLevel(Data.instance.enemy_hard, enemy_hard);

        StartCoroutine(startWave(enemy_normal_line));
        StartCoroutine(startWave(enemy_normal_curve));
        StartCoroutine(startWave(enemy_hard));
    }

    void setupLevel(List<GameObject> data, List<GameObject> wave)
    {
        foreach(GameObject obj in data)
        {
            wave.Add(obj);
        }
    }

    IEnumerator startWave(List<GameObject> _Waves)
    {
        int _CurrentWave = 0;
        if (_Waves.Count == 0)
        {
            yield break;
        }

        while (true)
        {
            while (_gameManager.gameState != GameState.Play)
            {
                yield return 0;
            }

            if (_CurrentWave < _Waves.Count)
            {
                GameObject wave = (GameObject)Instantiate(_Waves[_CurrentWave], transform.position, Quaternion.identity);

                wave.transform.parent = transform;

                while (0 < wave.transform.childCount)
                {
                    yield return 0;
                }

                Destroy(wave);
            }
            else
                yield return 0;

            _CurrentWave++;

            if (_CurrentWave >= _Waves.Count)
            {
                if (transform.childCount <= 0)
                {
                    _gameManager.gameWin();
                    Destroy(gameObject);
                }
                
            }
        }
    }
}
