using AirportTest.Contracts.Logger;
using AirportTest.Contracts.Service;
using AirportTest.Entities.ExtendedModels;
using AirportTest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AirportTest.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private ILoggerManager _logger;
        private IAirportService _airportService;

        public AirportController(ILoggerManager logger, IAirportService airportService)
        {
            _logger = logger;
            _airportService = airportService;
        }

        // GET: api/Airport
        /// <summary>
        /// Get a list of airports.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IList<AirportTest.Entities.Models.Airport>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public IActionResult GetAllAirports()
        {
            try
            {
                var airports = _airportService.GetAll();
                _logger.LogInfo("Returned all airports");
                return Ok(airports);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportController::GetAllAirports::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// GET: api/airport/FROM/TO
        /// Get distance between FROM to TO
        /// </summary>
        /// <param name="from">Source airport</param>
        /// <param name="to">Final airport</param>
        [HttpGet("{from}/{to}")]
        public IActionResult CalculateDistance(string from, string to)
        {
            try
            {
                var airportExtendedFrom = GetAirportByIata(from);
                var airportExtendedTo = GetAirportByIata(to);

                var locationFrom = airportExtendedFrom.Location.Lat + "," + airportExtendedFrom.Location.Lon;
                var locationTo = airportExtendedTo.Location.Lat + "," + airportExtendedTo.Location.Lon;


                var distance = 0;
                string apiKey = "AIzaSyBXAyMJFv1mtNSLz0HQOIJXVDCGtPoY3Qo";
                string apiUrl = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins={0}&destinations={1}&key={2}";
                apiUrl = string.Format(apiUrl, locationFrom, locationTo, apiKey);

                WebRequest request = HttpWebRequest.Create(apiUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string responseStringData = reader.ReadToEnd();
                var measureDistanceResponse = JsonConvert.DeserializeObject<MeasureDistanceResponse>(responseStringData);

                if (measureDistanceResponse == null || measureDistanceResponse.rows[0].elements[0].status == Constants.Responses.ZERO_RESULTS)
                {
                    throw new Exception("Unable to get meassurement from Google, seem there are an issue with the airport location");
                }
                else
                {
                    distance = measureDistanceResponse.rows[0].elements[0].distance.value;
                }

                return Ok($"Distance from {from} ({airportExtendedFrom.Name}) to {to}({airportExtendedTo.Name}) is: {distance} miles");
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportController::CalculateDistance::{ex.Message}");
                //return new StatusCodeResult(500);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        
        // GET: api/Airport/5/Location
        [HttpGet("{airportId}/location")]
        public IActionResult GetAiportWithDetails(Guid airportId)
        {
            try
            {
                var airportExtended = _airportService.GetAirportWithDetails(airportId);

                if (airportExtended.AirportId.Equals(Guid.Empty))
                {
                    _logger.LogError($"Airport with id: {airportId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details for id: {airportId}");
                    return Ok(airportExtended);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportController::GetAiportWithDetails::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        // GET: api/Airport/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Airport
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Airport/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Get airport filtered by IATA
        /// </summary>
        private AirportExtended GetAirportByIata(string iata)
        {
            try
            {
                return _airportService.GetAirportByIata(iata);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportController::GetAirportByIata::{ex.Message}");
                throw new Exception($"AirportController::GetAirportByIata", ex);
            }
        }
    }
}
