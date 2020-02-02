using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    private float _timer = 0F;
    private State _state = State.Spawning;
    private Vector3 _initPos = Vector3.zero;

    public GameObject Player;
    public GameObject Spawn;
    public GameObject Dispawn;
    public int ActionTimer;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<CharacterControlSystem>().OnDisable();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.Spawning: Spawning(Spawn.transform.position);
                break;
            case State.MovingRight: Moving(0, State.GlaringRight);
                break;
            case State.MovingLeft: Moving(Dispawn.transform.position.x, State.Dispawning);
                break;
            case State.GlaringRight: Glare(-180, State.GlaringLeft);
                break;
            case State.GlaringLeft: Glare(180, State.MovingLeft);
                break;
            case State.Dispawning: Player.SetActive(false);
                _state = State.Spawning;
                break;
        }
    }

    private void Glare(int rotation, State next)
    {
        if (CheckTimer())
        {
            Player.transform.Rotate(Vector3.up, rotation);
            _timer = 0F;
            _state = next;
            _initPos = Player.transform.position;
        }
    }

    private void Moving(float targetX, State next)
    {
        var target = new Vector3(targetX, Player.transform.position.y, Player.transform.position.z);
        _timer += Speed * Time.deltaTime;
        Player.transform.position = Vector3.Lerp(_initPos, target, _timer / ActionTimer);

        if (Vector3.Distance(target, Player.transform.position) < 0.1F)
        {
            _state = next;
            _timer = 0F;
        }
    }

    private void Spawning(Vector3 position)
    {
        if (CheckTimer())
        {
            Player.transform.position = position;
            Player.SetActive(true);
            Player.GetComponent<PlayerGameController>().SetRandomSprite();
            _state = State.MovingRight;
            _initPos = position;
            _timer = 0F;
        }
    }

    private bool CheckTimer()
    {
        _timer += Time.deltaTime;

        return _timer >= ActionTimer;
    }

    private enum State
    {
        Spawning,
        MovingRight,
        MovingLeft,
        GlaringRight,
        GlaringLeft,
        Dispawning
    }
}
