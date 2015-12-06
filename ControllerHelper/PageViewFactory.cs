using System.Collections.Generic;
using WalkUpAdvertisingShellWeb.Models;

namespace WalkUpAdvertisingShellWeb.ControllerHelper
{
    public class PageViewFactory
    {
        public static List<ItemGroupSection> GetDeviceLinkPartials(string userId)
        {
            var retrieveDeviceLinks = new List<ItemGroupSection>();

            retrieveDeviceLinks.Add(CreateDeviceGroupSection(userId));

            return retrieveDeviceLinks;
        }

        public static ItemGroupSection CreateDeviceGroupSection(string userId)
        {
            var personGroupSection = new DeviceGroupSection(userId);
            return personGroupSection;
        }
    }
}