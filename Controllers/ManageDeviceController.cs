using WalkUpAdvertisingShellWeb.ControllerHelper;
using WalkUpAdvertisingShellWeb.Models;
using WalkUpAdvertisingShellWeb.Services;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WalkUpAdvertisingShellWeb.Controllers
{
    [Authorize]
    public class ManageDeviceController : ControllerBase
    {
        // GET: ManageDevice
        public ActionResult Index()
        {
            string userId = GetUserId();

            var model = new ManageDeviceIndexViewModel();
            model.PageRenderActions = PageViewFactory.GetDeviceLinkPartials(userId);

            return View(model);
        }

        public ActionResult RegisterDevice()
        {
            var registerDeviceViewModel = new RegisterDeviceViewModel();

            return View(registerDeviceViewModel);
        }

        [HttpPost]
        public ActionResult RegisterDevice(RegisterDeviceViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var deviceSalt = ManageDeviceService.GetDeviceSalt(model.DeviceId);

            if (String.IsNullOrEmpty(deviceSalt))
            {
                ModelState.AddModelError("InvalidDevice","Device does not exist");
                return View(model);
            }

            var hashedPassword = Crypto.Hash(String.Format("{0}{1}", model.Password, deviceSalt));

           var deviceRegistered = ManageDeviceService.RegisterDevice(model.DeviceId, hashedPassword, GetUserId());

            if (!deviceRegistered)
            {
                ModelState.AddModelError("InvalidCredentials", "Invalid Credentials Or Device Does Not Exist");
                return View(model);
            }


            return RedirectToAction("Index");

        }


        public ActionResult UpdateDevice(string id)
        {

            var device = ManageDeviceService.GetRegisteredDevice(id);


            var updateDeviceViewModel = new UpdateDeviceViewModel(device);
            return View(updateDeviceViewModel);
        }

        public async Task<ActionResult> _ExistingDevice(string ids)
        {


            using (var dbContext = new ApplicationDbContext())
            {

                string userId = GetUserId();
                var devices = ManageDeviceService.GetRegisteredDevicesForUser(userId);

                var model = new DeviceSectionViewModel(devices);

                return View("Partial/_DeviceLinkPartial", model);
            }

        }

    }
}