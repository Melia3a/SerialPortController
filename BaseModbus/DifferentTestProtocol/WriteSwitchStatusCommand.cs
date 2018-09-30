using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferentTestProtocol
{
    public class WriteSwitchStatusCommand:BaseCommand
    {
        public WriteSwitchStatusCommand()
        {
            FunctionCode = 0x05;
        }
        public ushort SwitchStatus { get; set; }
        /*
         * 从机地址	1	01　　　
        功能码	1	05　　　
        起始地址	2	07D0　　起始地址为2000
        写入数据	2	FF 00　  写1个线圈M值，FF00 表示1
        CRC码	2	8C B7　　CRC16校验码
         * */
        public override byte[] CommandToBytes()
        {
            byte[] command = { SlaveAddress, (byte)FunctionCode, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            command[2] = (byte)(StartAddress >> 8 & 0xff);
            command[3] = (byte)(StartAddress & 0xff);

            command[4] = (byte)(SwitchStatus >> 8 & 0xff);
            command[5] = (byte)(SwitchStatus & 0xff);

            return command;
        }

        public override string GetInfomation()
        {
            return string.Format("指令类型：{0}；数据起始位置：{1}；开关状态：{2}",
               FunctionCode.ToString("X2"),
               StartAddress.ToString("X2"),
               SwitchStatus.ToString("X2"));
        }
    }
}
