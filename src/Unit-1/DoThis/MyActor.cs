using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Event;

namespace WinTail
{
    class MyActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Unhandled(message);

        }
    }
}
