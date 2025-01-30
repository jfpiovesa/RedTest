using System;
using Unity.AppUI.UI;
using UnityEngine;

public class PlayerControler : CharacterBase, I_DamageTake<DamageData>
{

    [Header("Tager Cam")]
    public Transform target_Cam = null;


    [Header("Components")]
    [SerializeField] Animator m_animator;
    [SerializeField] private CharacterController m_characterControler;
    [SerializeField] private PlayerAttack playerAttack;


    [Header("Moviment")]
    [SerializeField] private float m_walkingSpeed = 4f;
    [SerializeField] private float m_springSpeed = 8f;
    [SerializeField] public float m_turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;
    [SerializeField] private Vector2 m_direction = Vector2.zero;
    [SerializeField] private Vector3 m_moviment = Vector3.zero;

    [Header("Jump player ")]
    [SerializeField] private float m_jumpForce = 100;
    [SerializeField] private float m_delayJumpValueSet = 0.2f;
    private float delayJump;

    [Header("Gravity")]
    [SerializeField] private float _gravity = 15f;
    [SerializeField] private float _verticalSpeed;

    InputSystem_Actions inputActions;
    private void Awake()
    {
        Inicialized();
    }
    private void OnEnable()
    {
        OS_PlayerInGame.Player = this;

        inputActions.Enable();
    }
    private void Update()
    {
        CheckGround();

        m_direction = inputActions.Player.Move.ReadValue<Vector2>();

        if (inputActions.Player.Attack.WasReleasedThisFrame())
        {

            switch (playerAttack.currentCombo)
            {
                case 0:
                    playerAttack.Attack("Attack", 0);
                    break;
                case 1:
                    playerAttack.Attack("Attack", 1);
                    break;
                case 2:
                    playerAttack.Attack("Attack", 2);
                    break;
                default:
                    playerAttack.Attack("Attack", 0);
                    break;
            }
        }


        if (inputActions.Player.Jump.WasPressedThisFrame())
        {
            playerAttack.SpecialBegin();
            m_states.isFreeze = true;
        }
        if (inputActions.Player.Jump.WasReleasedThisFrame())
        {
            playerAttack.SpecialEnd();
            m_states.isFreeze = false;
        }

    }
    void FixedUpdate()
    {
        Moviment();
    }
    private void OnDisable()
    {
        OS_PlayerInGame.Player = null;
        inputActions.Disable();
    }
    private void OnDestroy()
    {
        OS_PlayerInGame.SetTarget(null);
    }
    public override void Inicialized()
    {
        base.Inicialized();


        if (m_states == null)
        {
            m_states = GetComponent<StatesCharacter>();
        }
        if (m_characterControler == null)
        {
            m_characterControler = GetComponent<CharacterController>();
        }
        if (playerAttack == null)
        {
            playerAttack = GetComponent<PlayerAttack>();
        }

        OS_PlayerInGame.Player = this;
        OS_PlayerInGame.SetTarget(target_Cam);


        inputActions = new InputSystem_Actions();
        inputActions.Enable();

    }
    public override void Moviment()
    {
        base.Moviment();

        if (m_states.stateHealth.Equals(StateHealth.IsDie)) return;

        if (m_states.canControl)
        {


            if (m_direction != Vector2.zero)
            {
                if (m_states.isFreeze) return;

                if (m_states.isGround)
                {
                    float targetAngle = Mathf.Atan2(m_direction.x, m_direction.y) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, m_turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }
                else
                {
                    float pAngle = Mathf.Atan2(m_direction.x * 2, m_direction.y * 2) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, pAngle, 0);
                }
            }
            else
            {
                m_moviment = Vector3.zero;
            }

            if (m_states.isGround)
            {
               
                    m_moviment = new Vector3(m_direction.x, 0, m_direction.y).normalized;
              
            }
            else
            {
                m_moviment.x = m_direction.x * 1.1f;
                m_moviment.z = m_direction.y * 1.1f;

                _verticalSpeed -= _gravity * Time.deltaTime;

            }
            if (delayJump > 0 && m_states.isGround)
            {
                delayJump = delayJump - Time.deltaTime;
            }

            if (m_characterControler.enabled)
            {
                m_moviment.y = _verticalSpeed;
            }



            float speed = m_states.isSpring == false ? m_walkingSpeed : m_springSpeed;
            m_characterControler.Move(m_moviment * speed * Time.deltaTime);

        }

        float speedAniamtion = m_states.isFreeze == true ? 0 : m_characterControler.velocity.magnitude;

        m_animator.SetFloat("Speed", speedAniamtion);
        m_animator.SetBool("isGround", m_states.isGround);
        m_animator.SetBool("isFalling", m_states.isFalling);

    }

    public override void CheckGround()
    {
        base.CheckGround();

        if (m_characterControler == null) return;

        m_states.isGround = m_characterControler.isGrounded;
        m_states.isFalling = !m_states.isGround;
    }

    public void ApplyDamage(DamageData damageData)
    {
        if (m_health == null) return;
        if (m_states.stateHealth.Equals(StateHealth.IsDie)) return;

        m_health.RemoveValue(damageData.damage);
        m_health.Action(damageData);

    }

    public override void Teleportation(Vector3 valuePosition, Quaternion valueRotation, Action succesAction)
    {

        StopActions(true);
        m_characterControler.enabled = false;
        base.Teleportation(valuePosition, valueRotation, succesAction);
        m_characterControler.enabled = true;
        succesAction?.Invoke();

    }
    public void StopActions(bool value)
    {
        m_states.isFreeze = value;
    }
}
