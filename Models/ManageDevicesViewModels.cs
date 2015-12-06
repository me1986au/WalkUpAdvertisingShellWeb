using WalkUpAdvertisingShellWeb.Services;
using WalkUpAdvertisingShellWeb.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WalkUpAdvertisingShellWeb.Models
{
    public class RegisterDeviceViewModel
    {
        [Required]
        [Display(Name = "Device Id")]
        public string DeviceId { set; get; }

        [Required]
        [Display(Name = "Password")]
        public string Password { set; get; }

    }

    public class UpdateDeviceViewModel
    {
        public UpdateDeviceViewModel()
        {

        }

        public UpdateDeviceViewModel(DeviceDto dto)
        {
            DeviceId = dto.DeviceId;
        }


        [Required]
        [Display(Name = "Device Id")]
        public string DeviceId { set; get; }


    }

    public class ManageDeviceIndexViewModel
    {
        public List<ItemGroupSection> PageRenderActions { get; set; }

        public ManageDeviceIndexViewModel()
        {

        }

    }

    public class DeviceSectionViewModel
    {

        public List<DeviceLinkDto> DeviceLinks { get; set; }

        public DeviceSectionViewModel(List<DeviceDto> devices)
        {
            DeviceLinks = devices.Select(x => new DeviceLinkDto(x)).ToList();
        }

        public class DeviceLinkDto : LinkDto
        {
            public DeviceLinkDto(DeviceDto device)
            {
                if (device != null)
                {
                    Id = device.DeviceId;
                }
            }



            public override string EditUrl
            {
                get
                {
                    return string.Format("ManageDevice/UpdateDevice?id={0}", Id);
                }
            }

            public override string DeleteUrl
            {
                get
                {
                    return string.Format("ManageDevice/DeactivateDevice?id={0}", Id);
                }
            }

            public string LinkLabelText
            {
                get { return String.Format("{0}", Id); }

            }
        }
    }

    public abstract class LinkDto
    {
        public string Id { get; set; }
        public abstract string EditUrl { get; }
        public abstract string DeleteUrl { get; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }
}