using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerDataSO playerData;
    public float hp = 100f;
    public float damage = 10f;
    public float moveSpeed = 5f;
    public Vector2 fireDir;
    public Vector2 moveDir;
    public float interval;
    public int projectileCount;
    public int pierceCount;

    //public Animator IndicatorAnim;
    public Animator anim;
    public SkillSlot[] skillSlots;

    public SpriteRenderer spriteRenderer;

    public int Level => level + 1;

    public float Damage => damage;
    // public float Damage { get { return damage * Level; } }
    public int KillCount { get; set; }
    public int TotalKillCount { get; set; }
    public float hpAmount { get { return hp / maxHp; } }

    public int exp = 0;
    private int level = 0;
    private List<int> levelupSteps = new List<int> { 100, 300, 500, 800, 1200 }; // ?좎뙇?먯삕 ?좎룞?쇿뜝?숈삕 5
    private int currentMaxExp => levelupSteps[level];
    private float maxHp;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        foreach (SkillSlot skillSlot in skillSlots)
        {
            skillSlot.CreatePrefab(transform);
        }
    }

    private void Start()
    {
        hp = playerData.hp;
        damage = playerData.damage;
        moveSpeed = playerData.moveSpeed;
        name = playerData.characterName;
        maxHp = hp;
        spriteRenderer.sprite = playerData.sprite;
        // GameObject ??뽮쉐????쑵??源딆넅 : SetActive
        // Componenet ??뽮쉐????쑵??源딆넅 : enabled
        spriteRenderer.GetComponent<Rotater>().enabled = playerData.rotateRenderer;

        Instantiate(playerData.startSkillPrefab, transform, false);

        KillCount = 0;
        GameManager.Instance.player = this;
    }

    private void Update()
    {
        if (Time.timeScale <= 0)
            return;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        if (x != 0 || y != 0)
            moveDir = new Vector2(x, y);
        anim.SetBool("isMoving", moveDir.magnitude > 0.6f);

        Enemy targetEnemy = null;
        float minDistance = float.MaxValue;

        // ?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕???좎룞?쇿뜝?숈삕 ?좎룞?숈튂?좎룞???좎뙣?듭삕 ?좎룞?쇿뜝?숈삕?좎룞???좎룞?쇿뜝?숈삕
        foreach (Enemy enemy in GameManager.Instance.enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetEnemy = enemy;
            }
        }
        if (targetEnemy != null)
            fireDir = targetEnemy.transform.position - transform.position;
    }
    private void FixedUpdate()
    {
        Move(moveDir);
    }

    // ?좎떇?곗삕?좎룞?쇿벴???좎떬?듭삕???좎룞?숉궗?좎룞???좎룞?쇿뜝?숈삕?좎룞???좎룞?숈찉?좎떊怨ㅼ삕???좎룞?쇿뜝?숈삕?좎룞?쇿뜝?숈삕?좎룞???좎룞?쇿뜝?숈삕?좎룞?쇿뜝?숈삕?좎룞???좎룞?숈껜
    public void OnSkillLevelUp(SkillSlot skillSlot)
    {
        if (skillSlot.skillLevel >= skillSlot.skillPrefabs.Length - 1)
        {
            // ?좎룞?숉슚?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕 ?좎룞?숉궗
            Debug.LogWarning($"?좎뙇?먯삕 ?좎룞?쇿뜝?숈삕?좎룞???좎룞?쇿뜝?숈삕?좎룞???좎룞?숉궗 ?좎룞?쇿뜝?숈삕?좎룞?쇿뜝?숈삕 ?좎떆?몄삕?좎룞?? {skillSlot.skillName}");
            return;
        }
        skillSlot.skillLevel++;

        skillSlot.CreatePrefab(transform);
        //skillSlot.currentSkillOjbect = Instantiate(skillSlot.skillPrefabs[skillSlot.skillLevel], transform, false);
        //skillSlot.currentSkillOjbect.name = skillSlot.skillPrefabs[skillSlot.skillLevel].name;
        //skillSlot.currentSkillOjbect.transform.localPosition = Vector2.zero;
        //if (skillSlot.isTargeting)
        //{
        //skill.currentSkillOjbect.transform.SetParent(fireDir);
        //}
    }





    /// <summary>
    ///	Transform?좎룞???좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕?좎룞?숉듃?좎룞???좎룞?쇿뜝?숈삕?좎떛?먯삕 ?좎뙃?쎌삕
    /// </summary>
    /// <param name="dir">?좎떛?몄삕 ?좎룞?쇿뜝?숈삕</param>
    public void Move(Vector2 dir)
    {
        //transform.Translate(dir * moveSpeed * Time.deltaTime);
        Vector2 movePos = rb.position + (dir * moveSpeed * Time.deltaTime);
        rb.MovePosition(movePos);
    }


    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
        else
        {
            // ?좎뙏?먯삕 ?좎뙇?덈챿?쇿뜝?깆눦?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕?좎룞?쇿뜝?깅챿???멨뜝?숈삕?좎떊紐뚯삕 ?좎뙥?쇱삕?좎룞?숉궎?좎룞???좎룞?쇿뜝?숈삕
            //AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
            //if (info.IsName("Hit") == false)

            // ?좎룞?쇿뜝?숈삕???좎떎寃⑹븷?덈챿?쇿뜝?깆눦??-> ?좎떎寃⑹븷?덈챿?쇿뜝?깆눦?쇿뜝?숈삕?좎룞???좎룞?쇿뜝?숈삕 Transition?좎룞??HitTrigger?좎룞???좎룞?쇿뜝?숈삕?좎뙥怨ㅼ삕 HasExitTime?좎룞??泥댄겕 ?좎룞?쇿뜝?숈삕?좎뙏?쎌삕 Hit?좎떦紐뚯삕 ?좎뙐濡쒕컮琉꾩삕
            // ?좎뙏?먯삕 ?좎뙇?덈챿?쇿뜝?깆눦?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕?덆붷뜝??좎뙥?먯삕.
            anim.SetTrigger("Hit");
        }
    }

    public void Die()
    {
        GameManager.Instance.GameOver();
    }

    public void Heal(float amount)
    {
        hp += amount;
        if (hp > maxHp)
            hp = maxHp;
    }

    public void GainExp(int exp)
    {
        this.exp += exp;
        if (level >= levelupSteps.Count)
        {
            int lastLevel = level - 1;
            levelupSteps.Add(levelupSteps[lastLevel] + levelupSteps[lastLevel] - levelupSteps[lastLevel - 1] + 100);
        }
        if (level < levelupSteps.Count && this.exp >= currentMaxExp)
        {
            OnLevelUp();
        }
    }

    private void OnLevelUp()
    {
        level++;
        UIManager.Instance.levelupPanel.gameObject.SetActive(true);
        UIManager.Instance.levelupPanel.LevelUpPanelOpen(skillSlots.ToList(), OnSkillLevelUp);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Item>(out Item item))
        {
            item.Contact();
        }

        // ?밧뜝?숈삕 ?닷뜝?숈삕?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕?좎룞?쇿뜝??좎떗怨ㅼ삕, ?좎룞?쇿뜝?숈삕?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕 ?좎룞?숈껜?좎룞?쇿뜝?숈삕 ?좎룞?숃뜎??좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕 ?좎뛿?쇿뜝?숈삕 ?좎뙏?듭삕 ?좎룞???좎룞?쇿뜝?
        // Interface?좎룞???좎룞?쇿뜝?숈삕???좎룞???좎뙇?먯삕.
        //if (collision.TryGetComponent<IContactable>(out IContactable contactable))
        //{
        //	contactable.Contact();
        //}

        // ?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕?좎룞?숉듃?좎룞???좎룞?쇿뜝?SendMessage?좎룞???좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕?좎룞???좎뙇?먯삕 ?좎룞?쇿뜝?숈삕?좎룞?숉듃?좎룞???밧뜝?숈삕 ?좎떛紐뚯삕?좎룞???좎룞?쇿뜝?숈삕 ?좎뙃?쎌삕?좎룞???멨뜝?숈삕?좎떦?몄삕?좎룞???좎떦?먯삕 ?좎룞?쇿뜝?숈삕???좎룞?쇿뜝?숈삕?좎떬?먯삕.	
        //collision.SendMessage("Contact", SendMessageOptions.DontRequireReceiver);
        // SendMessage ?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕?좎룞??
        // 1. ?좎룞?쇿뜝?섏슱?쇿뜝?숈삕 ?좎뙃?쎌삕?좎룞???멨뜝?숈삕?좎떦誘琉꾩삕 ?좎뙃?쎌삕 ?좎떛紐뚯삕 ?좎룞?쇿뜝?숈삕 ?좎떎?먯삕 ?좎룞?숉? ?좎뙥?쇱삕 ?좎룞???좎룞?쇿뜝?숈삕 李얍뜝?⑷? ?좎룞?쇿뜝?숈삕??
        // 2. ?좎뙏?먯삕 ?좎룞?숈껜?좎룞???좎뙇?먯삕 ?좎룞?쇿뜝??좎룞?쇿뜝?숈삕?좎룞?숉듃?좎룞?쇿뜝?숈삕 Contact?좎룞?쇿뜝??좎뙃?쎌삕?좎룞???좎룞?쇿뜝?숈삕?좎룞???좎뙇?먯삕?좎룞???먨뜝?숈삕?좎룞???좎룞?쇿뜝?숈삕?좎떦源띿삕 ?좎룞?쇿뜝?숈삕?좎룞???좎룞?쇿뜝?숈삕?좎뙆?숈삕?좎룞???ⓨ뜝?숈삕?좎룞?쇿뜝?깅씛?쇿뜝??좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?숈삕??
        // 3. ?멨뜝?숈삕?좎룞???좎뙃?쎌삕?좎룞???좎떇?곗삕?좎룞?쇿쭛??0?좎룞???좎떎?먯삕 1?좎룞?쇿뜝?숈삕 ?좎룞?쇿뜝?쇰맂?먯삕. 
    }

}
