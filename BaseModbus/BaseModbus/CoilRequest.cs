using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseModbus
{
    /// <summary>
    /// 读取线圈数据
    /// </summary>
    public abstract class ReadCoilRequest : RTUFrame
    {
        public ReadCoilRequest()
        {
            FunctionCode = 0x01;
        }
    }
    /// <summary>
    /// 向线圈写入单个数据
    /// </summary>
    public abstract class WriteSingleCoilRequest : RTUFrame
    {
        public WriteSingleCoilRequest()
        {
            FunctionCode = 0x05;
        }
    }
}
