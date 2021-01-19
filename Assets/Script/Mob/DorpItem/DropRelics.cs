using UnityEngine;

public class DropRelics : DropWeapon, IBulletTouchable
{
    //撃って壊れるアイテム
    //飛び出た破片は多分PLSweeperで取ると思う
    [SerializeField] private int maxhp = 10;
    [SerializeField] private int hp = 10;

    public void touchBullet(Bullet b)
    {
        hp -= b.weaponState.damage;
        if (hp <= 0)
        {
            effector.GemScatt(this.transform.position, 10);
            this.gameObject.SetActive(false);
        }
    }

    public override void ChangeWeapon(Weapon w)
    {
        dropWeapon = w;
        nameWriter.text = dropWeapon.weaponState.weaponName;
        hp = maxhp;
    }
}
