using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseModbus
{
    /// <summary>
    /// 读取保持寄存器数据
    /// </summary>
    public abstract class ReadHoldingRegisterRequest : RTUFrame
    {
        public ReadHoldingRegisterRequest()
        {
            FunctionCode = 0x03;    
        }
    }
}
