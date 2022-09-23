using System;
using System.Collections.Generic;

namespace DefaultNamespace.Dialogue
{
    [Serializable]
    public class ActorSpecificDialogue
    {
        public Actor actor;
        public List<Dialogue> conversation;
    }
}