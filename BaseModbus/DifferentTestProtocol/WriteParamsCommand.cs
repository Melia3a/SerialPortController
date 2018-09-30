using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferentTestProtocol
{
    public class WriteParamsCommand : BaseCommand
    {
        public WriteParamsCommand()
            : base()
        {
            FunctionCode = 0x10;
        }
        public ushort[] Params { get; set; }
        public override byte[] CommandToBytes()
        {
            byte[] command = new byte[9 + Params.Length * 2];
            command[0] = SlaveAddress;
            command[1] = (byte)FunctionCode;

            command[2] = (byte)(StartAddress >> 8 & 0xff);
            command[3] = (byte)(StartAddress & 0xff);

            command[4] = (byte)(Params.Length >> 8 & 0xff);
            command[5] = (byte)(Params.Length & 0xff);

            command[6] = (byte)(Params.Length * 2);

            for (int i = 0; i < Params.Length; i++)
            {
                command[7 + i * 2] = (byte)(Params[i] >> 8 & 0xff);
                command[8 + i * 2] = (byte)(Params[i] & 0xff);
            }
            return command;
        }

        public override string GetInfomation()
        {
            StringBuilder paramsString = new StringBuilder();
            foreach (var p in Params)
            {
                paramsString.Append(p.ToString() + " ");
            }
            return string.Format("指令类型：{0}；数据起始位置：{1}；数据长度：{2}；数据值(整数类型)：{3}", FunctionCode.ToString(), StartAddress.ToString("X2"), Params.Length, Params.ToString());
        }
    }
}
