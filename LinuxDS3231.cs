using System;
using System.Collections.Generic;
using System.Text;

namespace LinuxI2CDS3231Example
{
    public class LinuxDS3231
    {
        private ILinuxI2C i2c;
        private int i2c_fd = -1;
        private int i2c_device_addr = 0;

        private const int RTC_SEC_REGISTER_OFFSET = 0x00;
        private const int RTC_MIN_REGISTER_OFFSET = 0x01;
        private const int RTC_HRS_REGISTER_OFFSET = 0x02;
        public LinuxDS3231(ILinuxI2C i2cInterface, string i2cBus, int deviceAddress)
        {
            i2c = i2cInterface;
            i2c_device_addr = deviceAddress;
            i2c_fd = i2c.Open(i2cBus, 2);
            if (i2c_fd <= 0)
            {
                throw new Exception("Unable to open the i2c bus, some configuration wrong?");
            }
        }

        public void SetSeconds(int seconds)
        {
            if (seconds >= 60 || seconds <= 0)
            {
                //Wrap to 0 seconds...
                seconds = 0;
            }
            try
            {
                //Just do a regular i2c value write...
                i2c.RegWriteByte(i2c_fd, (short)i2c_device_addr, RTC_SEC_REGISTER_OFFSET, (short)seconds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? ReadSeconds()
        {
            int secsRead = 0;
            try
            {
                i2c.RegReadByte(i2c_fd, (short)i2c_device_addr, RTC_SEC_REGISTER_OFFSET, ref secsRead);
                return secsRead;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? ReadMinute()
        {
            int minsRead = 0;
            try
            {
                i2c.RegReadByte(i2c_fd, (short)i2c_device_addr, RTC_MIN_REGISTER_OFFSET, ref minsRead);
                return minsRead;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? ReadHour() //TODO fix hours result
        {
            int hoursRead = 0;
            try
            {
                i2c.RegReadByte(i2c_fd, (short)i2c_device_addr, RTC_HRS_REGISTER_OFFSET, ref hoursRead);
                return hoursRead;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
