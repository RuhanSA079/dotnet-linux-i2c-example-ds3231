using System;
using System.Collections.Generic;
using System.Text;

namespace LinuxI2CDS3231Example
{
    public interface ILinuxI2C
    {
        int Open(string device, int mode);
        void Close(int fd);
        void RegReadByte(int fd, int devaddr, int regaddr, ref int content);
        void RegWriteByte(int fd, Int16 addr, Int16 cmd, Int16 val);
        void RegReadByte(int fd, sbyte addr, sbyte cmd, ref sbyte val);
        void URegReadShort(int fd, Int16 addr, UInt16 cmd, ref UInt16 val);
        void SRegReadShort(int fd, Int16 addr, Int16 cmd, ref Int16 val);
        void RegRead24(int fd, sbyte addr, Int16 cmd, ref Int16 val);
        void RegWriteBytes(int fd, sbyte addr, Int16 cmd, Int16[] content);
    }
}
