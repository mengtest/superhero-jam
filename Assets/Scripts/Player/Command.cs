using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{

    public virtual void Execute() { }
}

public class MoveUp : Command{

        private Player player;

        public MoveUp(Player player) {
            this.player = player;
        }

        public override void Execute(){
            player.MoveUp();
        }
}

public class MoveDown : Command{

        private Player player;

        public MoveDown(Player player) {
            this.player = player;
        }

        public override void Execute(){
            player.MoveDown();
        }
}

public class Jump : Command{

    private Player player;

    public Jump(Player player){
        this.player = player;
    }

    public override void Execute(){
        player.Jump();
    }
}