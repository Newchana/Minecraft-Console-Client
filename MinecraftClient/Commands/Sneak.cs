﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftClient.Commands
{
    public class Sneak : Command
    {
        private bool sneaking = false;
        public override string CMDName { get { return "Sneak"; } }
        public override string CMDDesc { get { return "Sneak: Toggles sneaking"; } }

        public override string Run(McClient handler, string command, Dictionary<string, object> localVars)
        {
            if (sneaking)
            {
                var result = handler.SendEntityAction(Protocol.EntityActionType.StopSneaking);
                if (result)
                    sneaking = false;
                return  result ? "You aren't sneaking anymore" : "Fail";
            }
            else
            {
                var result = handler.SendEntityAction(Protocol.EntityActionType.StartSneaking);
                if (result)
                    sneaking = true;
                return  result ? "You are sneaking now" : "Fail";
            }
            
        }
    }
}