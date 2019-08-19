using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    //? I've never seen this new way of creating a reference.
    //? In this case we've created the Animator reference within the method itself. cool
    public abstract void Execute(Animator anim);
}

public class PerformJump: Command {
    public override void Execute(Animator anim){
        anim.SetTrigger("isJumping");
    }
}

public class DoNothing:Command {
    public override void Execute(Animator anim){
        
    }
}