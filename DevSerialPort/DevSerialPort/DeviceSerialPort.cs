using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Timers;
using CRCClass;
namespace DevSerialPort
{
    public class DeviceSerialPort
    {
        public delegate void DataReceiveEventHandler(object sender,ReceivedDataEventArgs e); 
        public event DataReceiveEventHandler dataReceived;

        //单独的串口类
        //用于设置指令CRC校验码并发送、接收返回后进行CRC校验
        SerialPort sPort;

        public DeviceSerialPort()
        {
            sPort = new SerialPort();
            sPort.DataReceived += sPort_DataReceived;
        }

        void sPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReceivedDataEventArgs receiveDataEventArgs = new ReceivedDataEventArgs();
            try
            {
                //获取数据后校验并将数据返回给处理类
                byte[] buffer;
                byte[] dataLength = new byte[3];
                for (int i = 0; i < dataLength.Length; i++)
                    dataLength[i] = (byte)sPort.ReadByte();
                switch (dataLength[1])
                {
                    case 0x01:
                    case 0x03:
                        buffer = new byte[5 + dataLength[2]];
                        break;
                    default: buffer = new byte[8];
                        break;
                }
                Array.Copy(dataLength, buffer, dataLength.Length);
                for (int i = 3; i < buffer.Length; i++)
                    buffer[i] = (byte)sPort.ReadByte();
               
                receiveDataEventArgs.ReceiveDataBytes = buffer;
                if (CRCVerify.checkedCRC(buffer))
                {
                    receiveDataEventArgs.IsCRCVerifyError = false;
                }
                else receiveDataEventArgs.IsCRCVerifyError = true;
                //返回给处理类
                dataReceived(this, receiveDataEventArgs);
            }
            catch 
            {   
            }
            
        }
       
        #region Port参数配置
        public void SetComName(string comName)
        {
            sPort.PortName = comName;
        }
        public void SetBaudRate(int baudRate)
        {
            sPort.BaudRate = baudRate;
        }
        public void SetStopBits(StopBits stopBits)
        {
            sPort.StopBits = stopBits;
        }
        public void SetDataBits(int dataBits)
        {
            sPort.DataBits = dataBits;
        }
        public void SetParity(Parity parity)
        {
            sPort.Parity = parity;
        }
        #endregion
        #region operation
        public void OpenPort()
        {
            try
            {
                sPort.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public void ClosePort()
        {
            try
            {
                if (sPort.IsOpen) sPort.Close();
               
            }
            catch (Exception ex) { throw ex; }
        }
     
        public void SendCommand(byte[] command)
        {
            System.Threading.Thread.Sleep(500);
            command=CRCVerify.SetCRC16(command);
            sPort.Write(command, 0, command.Length);
        //    Task.Delay(millisecondsTimeout).Wait();
        }
        public bool PortIsOpen()
        {
            return sPort.IsOpen;
        }
        #endregion
    }

    public class ReceivedDataEventArgs : EventArgs
    {
        // 摘要:
        //     返回接收到数据。
        //
        // 返回结果:
        //     返回接收到的数据
        public byte[] ReceiveDataBytes { get; set; }
        // 摘要:
        //     CRC校验结果。
        //
        // 返回结果:
        //     CRC校验结果
        public bool IsCRCVerifyError { get; set; }
    }
    
}
