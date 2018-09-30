using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DifferentTestProtocol
{
    public class ReadRemoteDataCommand : BaseCommand
    {
        public ReadRemoteDataCommand()
            : base()
        {
            FunctionCode= 0x03;
        }
        public ushort GetItemCount { get; set; }

        public override byte[] CommandToBytes()
        {
            byte[] command = { SlaveAddress, (byte)FunctionCode, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            command[2] = (byte)(StartAddress >> 8 & 0xff);
            command[3] = (byte)(StartAddress & 0xff);
            command[4] = (byte)(GetItemCount >> 8 & 0xff);
            command[5] = (byte)(GetItemCount & 0xff);
            return command;
        }

        public override string GetInfomation()
        {
            return string.Format("指令类型：{0}；数据起始位置：{1}；数据长度：{2}字节", FunctionCode.ToString("X2"), StartAddress.ToString("X2"), GetItemCount);
        }
    }
}
