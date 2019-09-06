﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PBS.Business.Core.BusinessModels;
using PBS.Business.Core.Models;
using PBS.Web.Helpers;
using PBS.Web.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace PBS.Web.Controllers
{
    public class ParkingLotController : Controller
    {
        private readonly IApiHelper _apiHelper;
        private readonly ITokenDecoder _tokenDecoder;
        private readonly IConfiguration _configuration;

        public ParkingLotController (IApiHelper apiHelper,
                                     ITokenDecoder tokenDecoder,
                                     IConfiguration configuration)
        {
            _apiHelper = apiHelper;
            _tokenDecoder = tokenDecoder;
            _configuration = configuration;
        }

        #region Dashboard
        public IActionResult Dashboard ()
        {
            ResponseDetails response = _apiHelper.SendApiRequest ("", "parkinglot/get/user/" + _tokenDecoder.UserId, HttpMethod.Get);

            if (response.Success)
            {
                List<ParkingLotViewModel> model = JsonConvert.DeserializeObject<List<ParkingLotViewModel>> (response.Data.ToString ());

                return View (model);
            }
            else
            {
                ErrorViewModel model = new ErrorViewModel
                {
                    Message = response.Data.ToString ()
                };

                return View ("Error", model);
            }
        }
        #endregion

        #region Add new parking lot
        [HttpGet]
        public IActionResult Add ()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult Add (AddParkingLotModel model)
        {
            if (ModelState.IsValid)
            {
                ParkingLotViewModel lot = new ParkingLotViewModel ()
                {
                    Name = model.Name,
                    IsActive = true,
                    IsAproved = false,
                    OwnerId = _tokenDecoder.UserId,
                    AddressViewModel = model.AddressViewModel
                };

                for (int i = 0; i < model.NoOf2WheelSlot; i++)
                {
                    lot.SlotViewModels.Add (new SlotViewModel ()
                    {
                        IsBooked = false,
                        SlotTypeId = 1
                    });
                }

                for (int i = 0; i < model.NoOf4WheelSlot; i++)
                {
                    lot.SlotViewModels.Add (new SlotViewModel ()
                    {
                        IsBooked = false,
                        SlotTypeId = 2
                    });
                }

                ResponseDetails response = _apiHelper.SendApiRequest (lot, "parkinglot/add", HttpMethod.Post);

                if (response.Success)
                {
                    return RedirectToAction ("Dashboard");
                }
                else
                {
                    ErrorViewModel errorModel = new ErrorViewModel
                    {
                        Message = response.Data.ToString ()
                    };

                    return View ("Error", errorModel);
                }
            }
            else
            {
                ModelState.AddModelError ("Error", "Validation Error");
                return View (model);
            }
        }
        #endregion

        #region Details
        public IActionResult Details (int id)
        {
            ResponseDetails response = _apiHelper.SendApiRequest ("", "parkinglot/get/" + id, HttpMethod.Get);

            if (response.Success)
            {
                ParkingLotViewModel model = JsonConvert.DeserializeObject<ParkingLotViewModel> (response.Data.ToString ());

                return View (model);
            }
            else
            {
                ErrorViewModel model = new ErrorViewModel
                {
                    Message = response.Data.ToString ()
                };

                return View ("Error", model);
            }
        }
        #endregion

        #region Update

        [HttpPost]
        public IActionResult Update (ParkingLotViewModel model)
        {
            if (ModelState.IsValid)
            {
                ResponseDetails response = _apiHelper.SendApiRequest (model, "parkinglot/update", HttpMethod.Post);

                if (response.Success)
                {
                    return RedirectToAction ("Details", new { id = model.Id });
                }
                else
                {
                    ErrorViewModel errorModel = new ErrorViewModel
                    {
                        Message = response.Data.ToString ()
                    };

                    return View ("Error", errorModel);
                }
            }
            else
            {
                ModelState.AddModelError ("Error", "Validation Error");
                return View (model);
            }
        }
        #endregion
    }
}