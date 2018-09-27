# SerialPortController

Serial communication with the device using a simple modbus protocol.

## Simple Modbus Protocol
### Request 
Request to read Data using Function 03
```table
Field Name|Number of bytes|Example（Hex）
Address of Device|1	|01
Function	|1	|03
Start Address of Data|2	|00 00
Number of Data Read|2	|00 0C
CRC	|2	|45 CF　　
```
### Response
```table
Field Name|Number of bytes|Example（Hex）
Address of Device|1	|01
Function	|1	|03
Start Address of Data|2	|00 00
Number of Data Read|2	|00 0C
CRC	|2	|45 CF　　
```

