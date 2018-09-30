using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRCClass;
namespace BaseModbus
{
    public abstract class RTUFrame
    {
        //从机地址
        public byte SlaveAddress { get; set; }
        // 数据起始位置
        public ushort StartAddress { get; set; }
        //功能码
        public byte FunctionCode { get; set; }
        /// <summary>
        /// 将指令
        /// </summary>
        /// <returns></returns>
        public abstract byte[] CommandToBytes();

        /// <summary>
        /// 获取当前指令的相关信息
        /// </summary>
        /// <returns>指令信息</returns>
        public abstract string GetInfomation();
        /// <summary>
        /// 创建二进制数据指令
        /// </summary>
        /// <returns>返回二进制指令</returns>
        public byte[] CreateBytesCommand()
        {
            return CRC.AddCRCCodeToBytesArray(CommandToBytes());
        }
    }
}
