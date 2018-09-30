using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferentTestProtocol
{
    public class CurrentlyCommand
    {
       public BaseCommand Command;
       //指令状态
       public CommandStatus CurrentStatus { get; set; }
       //指令发送次数
       public int SendCount { get; set; }
       public CurrentlyCommand(BaseCommand command)
       {
           Command = command;
           SendCount = 0;
           CurrentStatus = CommandStatus.未发送;
       }
    }
}
