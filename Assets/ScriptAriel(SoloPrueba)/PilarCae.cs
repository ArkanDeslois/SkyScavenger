﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarCae : MonoBehaviour
{

  public CaePilar Roca;
  Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Roca.PilarCaer == true)
    {
      anim.SetInteger("State", 1);
    }
    }
}
