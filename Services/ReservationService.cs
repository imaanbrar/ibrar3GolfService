using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ibrar3GolfDataModel.Data;
using ibrar3GolfDataModel.Models;
using ibrar3GolfDataModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace ibrar3GolfService.Services
{
    public class ReservationService
    {
        private readonly GolfContext _context;

        public ReservationService(GolfContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationView>> GetReservationView()
        {
            var data = await _context.Reservation.Select(x => new ReservationView {
                Id = x.Id,
                TypeCode = x.TypeCode,
                UserId = x.UserId,
                Players = x.Players,
                IsApproved = x.IsApproved,
                StartDateTime = x.StartDateTime,
                EndDateTime = x.EndDateTime,
                RecurringRule = x.RecurringRule,
                RecurringDay = x.RecurringDay,
                UserName = x.User.Name,
                ReservationType = x.TypeCode == "O" ? "One Time" : "Standing"
            }).ToListAsync();
            return data;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            var data = await _context.Reservation.ToListAsync();
            return data;
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            var data = await _context.Reservation.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<ReservationView>> GetReservationsByUserId(int id)
        {
            var data = await _context.Reservation.Where(x => x.UserId == id).Select(x => new ReservationView
            {
                Id = x.Id,
                TypeCode = x.TypeCode,
                UserId = x.UserId,
                Players = x.Players,
                IsApproved = x.IsApproved,
                StartDateTime = x.StartDateTime,
                EndDateTime = x.EndDateTime,
                RecurringRule = x.RecurringRule,
                RecurringDay = x.RecurringDay,
                UserName = x.User.Name,
                ReservationType = x.TypeCode == "O" ? "One Time" : "Standing"
            }).ToListAsync();
            return data;
        }

        public async Task<bool> CreateReservation(Reservation reservation)
        {
            try
            {
                reservation.StartDateTime = reservation.StartDateTime.AddHours(-7);
                reservation = setReservation(reservation);
                await _context.Reservation.AddAsync(reservation);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Reservation> UpdateReservation(Reservation reservation)
        {
            try
            {
                reservation = setReservation(reservation);
                _context.Entry(reservation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return reservation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Reservation setReservation(Reservation reservation)
        {
            reservation.EndDateTime = reservation.StartDateTime.AddHours(2);
            if (reservation.TypeCode == "O")
            {
                reservation.IsApproved = true;
            }
            else
            {
                reservation.RecurringRule = "FREQ=WEEKLY;BYDAY=" + reservation.RecurringDay + ";COUNT=20";
            }
            return reservation;
        }

        public async Task<bool> DeleteReservation(int id)
        {
            try
            {
                var reservation = _context.Reservation.Find(id);
                _context.Reservation.Remove(reservation);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetUsersLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.User
                         where i.RoleCode == "S" || i.RoleCode == "M" 
                         select new
                         {
                             Value = i.Id,
                             Text = i.Name
                         };
            return DataSourceLoader.Load(lookup, loadOptions);
        }

    }
}
