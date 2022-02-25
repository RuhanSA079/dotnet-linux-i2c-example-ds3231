using System;

namespace LinuxI2CDS3231Example
{
    class Program
    {
        const int RTC_I2C_DEVICE_ADDRESS = 0x68;


        static void Main(string[] args)
        {
            Console.WriteLine("Example i2c Linux C# program");
            Console.ReadLine();
            try
            {
                //Initialise the library first!
                ILinuxI2C i2cBus = new LinuxI2Carm64();
                if (i2cBus != null)
                {
                    //Lets create a instance of the DS3231 library to use with the i2c library...
                    LinuxDS3231 rtc = new LinuxDS3231(i2cBus, "/dev/i2c-1", RTC_I2C_DEVICE_ADDRESS);
                    //Lets read the time (if set)
                    try
                    {
                        int? readHour = rtc.ReadHour();
                        int? readMin = rtc.ReadMinute();
                        int? readSec = rtc.ReadSeconds();
                        if (readHour != null && readMin != null && readSec != null)
                        {
                            //Print out the time...
                            Console.WriteLine($"Current time on the RTC is: {(int)readHour}:{(int)readMin}:{(int)readSec}");
                            Console.WriteLine("If you press the Enter key, we will attempt to reset the seconds, to verify that it has been set by the i2c library...");
                            Console.ReadLine();

                            readHour = rtc.ReadHour();
                            readMin = rtc.ReadMinute();
                            readSec = rtc.ReadSeconds();
                            if (readHour != null && readMin != null && readSec != null)
                            {
                                Console.WriteLine($"Current time on the RTC is: {(int)readHour}:{(int)readMin}:{(int)readSec}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong here...");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
            Environment.Exit(0);


        }
    }
}
