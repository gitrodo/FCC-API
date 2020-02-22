using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCheck_BE.Data;
using CreditCheck_BE.Dtos;
using CreditCheck_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditCheck_BE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressRepository"></param>
        public LocationsController(DataContext dataContext)
        {
            _dataContext = dataContext;
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

            // var returnedInformation = await _addressRepository.SearchAddress(addressDTO);
            var returnedInformation = await _dataContext.Addresses.Where(
                p => p.ZipCode.Contains(addressDTO.ZipCode) ||
                (p.HouseNumber == addressDTO.HouseNumber && p.StreetName == addressDTO.StreetName))
                .ToListAsync();

            if (returnedInformation != null)
                return Ok(returnedInformation);

            return BadRequest("Something went wrong, please try later");
        }
    }
}