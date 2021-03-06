﻿using System.Threading.Tasks;
using CreditCheck_BE.Data;
using CreditCheck_BE.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditCheck_BE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IAddress _addressRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressRepository"></param>
        public LocationsController(IAddress addressRepository)
        {
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        [HttpPost("lookup")]
        public async Task<IActionResult> LookUp(AddressDTO addressDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please, verify your information and try again");

            var returnedInformation = await _addressRepository.SearchAddress(addressDTO);

            if (returnedInformation != null)
                return Ok(returnedInformation);

            return BadRequest("Something went wrong, please try later");
        }
    }
}