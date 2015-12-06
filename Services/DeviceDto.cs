using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WalkUpAdvertisingShellWeb.Models;

namespace WalkUpAdvertisingShellWeb.Services
{
    public class DeviceDto
    {

        public DeviceDto(Device device)
        {
            DeviceId = device.Id;
            PasswordHash = device.PasswordHash;
            SecurityStamp = device.PasswordSalt;
            ApplicationUserId = device.ApplicationUserId;

        }

        public string DeviceId { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ApplicationUserId { get; set; }

    }
}