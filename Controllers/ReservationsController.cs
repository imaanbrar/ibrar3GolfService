using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ibrar3GolfDataModel.Models;
using ibrar3GolfDataModel.ViewModels;
using ibrar3GolfService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace ibrar3GolfService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationsController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<List<ReservationView>> GetReservationView()
        {
            return await _reservationService.GetReservationView();
        }

        [HttpGet]
        public async Task<List<Reservation>> GetReservations()
        {
            return await _reservationService.GetReservations();
        }

        [HttpGet]
        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationService.GetReservationById(id);
        }

        [HttpGet]
        public async Task<List<ReservationView>> GetReservationsByUserId(int id)
        {
            return await _reservationService.GetReservationsByUserId(id);
        }

        [HttpPost]
        public async Task<bool> PostReservation([FromBody] Reservation reservation)
        {
            return await _reservationService.CreateReservation(reservation);
        }

        [HttpPut]
        public async Task<Reservation> PutReservation([FromBody] Reservation reservation)
        {
            return await _reservationService.UpdateReservation(reservation);
        }

        [HttpDelete]
        public async Task<bool> DeleteReservation(int id)
        {
            return await _reservationService.DeleteReservation(id);
        }

        [HttpGet]
        public object GetUsersLookup(DataSourceLoadOptions loadOptions)
        {
            return _reservationService.GetUsersLookup(loadOptions);
        }

    }
}