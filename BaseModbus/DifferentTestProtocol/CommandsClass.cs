using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferentTestProtocol
{
    public class CommandsClass
    {
        public static BaseCommand CreateReadRDCmd(ushort startAddress, ushort getItemCount)
        {
            ReadRemoteDataCommand cmd = new ReadRemoteDataCommand();
            cmd.StartAddress = startAddress;
            cmd.GetItemCount = getItemCount;
            return cmd;
        }

        public static BaseCommand CreateReadRSCmd(ushort startAddress, ushort signalBitsCount)
        {
            ReadRemoteSignalCommand cmd = new ReadRemoteSignalCommand();
            cmd.StartAddress = startAddress;
            cmd.SignalBitsCount = signalBitsCount;
            return cmd;
        }
        public static BaseCommand CreateWriteParamsCommand(ushort startAddress, ushort[] Parameters)
        {
            WriteParamsCommand cmd = new WriteParamsCommand();
            cmd.Params = Parameters;
            cmd.StartAddress = startAddress;
            return cmd;
        }
        public static BaseCommand CreateWriteSwitchStatusCommand(ushort startAddress, ushort switchStatus)
        {
            WriteSwitchStatusCommand cmd = new WriteSwitchStatusCommand();
            cmd.StartAddress = startAddress;
            cmd.SwitchStatus = switchStatus;
            return cmd;
        }

    }
}
