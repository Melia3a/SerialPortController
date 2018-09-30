using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DifferentTestProtocol
{
    public class ReadRemoteSignalCommand : BaseCommand
    {
        public ReadRemoteSignalCommand()
            : base()
        {
            FunctionCode = 0x01;
        }
        /// <summary>
        /// 数据位数，为8的整数被
        /// </summary>
        public ushort SignalBitsCount { get; set; }
        public override byte[] CommandToBytes()
        {
            byte[] command = { SlaveAddress, (byte)FunctionCode, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            command[2] = (byte)(StartAddress >> 8 & 0xff);
            command[3] = (byte)(StartAddress & 0xff);
            command[4] = (byte)((SignalBitsCount) >> 8 & 0xff);
            command[5] = (byte)((SignalBitsCount) & 0xff);
            return command;
        }

        public override string GetInfomation()
        {
            return string.Format("指令类型：{0}；数据起始位置：{1}；数据长度：{2}b",
                FunctionCode.ToString("X2"),
                StartAddress.ToString("X2"),
                SignalBitsCount);
        }
    }
}
