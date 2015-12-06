using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using WalkUpAdvertisingShellWeb.Models;

namespace WalkUpAdvertisingShellWeb.Services
{
    public static class ManageDeviceService
    {

        public static bool RegisterDevice(string deviceId, string passwordHash, string applicationUserId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var device = dbContext.Devices.Where(x => x.Id == deviceId).FirstOrDefault();


                if (device != null && !device.IsDeviceRegistered && device.PasswordHash == passwordHash)
                {
                    device.ApplicationUserId = applicationUserId;
                    dbContext.Entry(device).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return true;

                }
            }


            return false;

        }


        public static List<DeviceDto> GetRegisteredDevicesForUser(string applicationUserId)
        {

            using (var dbContext = new ApplicationDbContext())
            {
                var devices = dbContext.Devices
                    .Where(x => x.ApplicationUserId == applicationUserId).ToList();

                var dtos = devices.Select(device => new DeviceDto(device)).ToList();

                return dtos;
            }

        }


        public static DeviceDto GetRegisteredDevice(string deviceId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var device = dbContext.Devices.Where(x => x.Id == deviceId).FirstOrDefault();

                if (device != null)
                {
                    return new DeviceDto(device);
                }

                return null;
            }
        }

        public static string GetDeviceSalt(string deviceId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var device = dbContext.Devices.Where(x => x.Id == deviceId).FirstOrDefault();

                if (device != null)
                {
                    return device.PasswordSalt;
                }

                return null;
            }
        }


    }
}