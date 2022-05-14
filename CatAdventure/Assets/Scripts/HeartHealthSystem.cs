using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthSystem
{
    public const int MAX_FRAGMENT_AMOUNT = 4;

    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDead;

    private List<Heart> heartList;

    //하트 개수 받아옴
    public HeartHealthSystem(int heartAmount)
    {
        heartList = new List<Heart>();
        for(int i = 0; i< heartAmount; i++)
        {
            Heart heart = new Heart(4);
            heartList.Add(heart);
        }
    }

    //리스트에 하트 넣어서 반환
    public List<Heart> GetHeartList()
    {
        return heartList;
    }

    public void Damage(int damageAmount)
    {
        //Cycle through all hearts starting from the end
        for(int i = heartList.Count-1;i>=0; i--)
        {
            Heart heart = heartList[i];
            //하트가 데미지를 받으면 
            if(damageAmount > heart.GetFragmentAmount())
            {
                //하트0일때 다음 하트가 데미지받음
                damageAmount -= heart.GetFragmentAmount();
                heart.Damage(heart.GetFragmentAmount());
            }
            else
            {
                //하트가 모두 0일때 break
                heart.Damage(damageAmount);
                break;
            }
        }
        if(OnDamaged != null) 
            OnDamaged(this, EventArgs.Empty);

        if(IsDead())
            if (OnDead != null)
                OnDead(this, EventArgs.Empty);
    }

    public void Heal(int healAmount)
    {
        for(int i = 0; i< heartList.Count; i++)
        {
            Heart heart = heartList[i];
            int missingFragments = MAX_FRAGMENT_AMOUNT - heart.GetFragmentAmount();

            if(healAmount > missingFragments)
            {
                healAmount -= missingFragments;
                heart.Heal(missingFragments);
            }
            else
            {
                heart.Heal(healAmount);
                break;
            }
        }
        if (OnHealed != null)
            OnHealed(this, EventArgs.Empty);
    }

    public bool IsDead()
    {
        return heartList[0].GetFragmentAmount() ==0;
    }

    //Represents a Single Heart
    public class Heart
    {
        private int fragments;

        public Heart(int fragments)
        {
            this.fragments = fragments;
        }

        public int GetFragmentAmount()
        {
            return fragments;
        }

        public void SetFragments(int fragments)
        {
            this.fragments = fragments;
        }

        public void Damage(int damageAmont)
        {
            if(damageAmont >= fragments)
            {
                fragments = 0;
            }
            else
            {
                fragments -= damageAmont;
            }
        }

        public void Heal(int healAmount)
        {
            if(fragments + healAmount > MAX_FRAGMENT_AMOUNT)
            {
                fragments = MAX_FRAGMENT_AMOUNT;
            }
            else
            {
                fragments += healAmount;
            }
        }
    }
}
