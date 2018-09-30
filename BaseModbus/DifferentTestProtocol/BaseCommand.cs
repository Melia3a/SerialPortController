using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseModbus;
namespace DifferentTestProtocol
{
    public abstract class BaseCommand : RTUFrame
    {
      
        //指令优先级
        public CommandPriority Priority { get; set; }
       
        
        public BaseCommand()
        {
            SlaveAddress = 0x01;
        }
    }
    public enum CommandPriority
    {
        //控制指令
        ControlCommand,
        //常规指令
        GeneralCommand
    }
    /// <summary>
    /// command的状态
    /// </summary>
    public enum CommandStatus
    {
        // 摘要:
        //   指令实例化。
        未发送,
        // 摘要:
        //    成功发送指令。
        已发送,
        // 摘要:
        //    成功接收返回数据。
        已接收,

        // 摘要:
        //    分析完成返回数据可以进行将指令从指令队列移除。
        分析结束
    }
}
