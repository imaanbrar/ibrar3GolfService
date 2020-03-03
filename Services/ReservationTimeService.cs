using ibrar3GolfDataModel.Data;
using ibrar3GolfDataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace ibrar3GolfService.Services
{
    public class ReservationTimeService
    {
        private readonly GolfContext _context;

        public ReservationTimeService(GolfContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationTime>> GetReservationTimes()
        {
            var data = await _context.ReservationTime.ToListAsync();
            return data;
        }

        public async Task<ReservationTime> GetReservationTimeById(int id)
        {
            var data = await _context.ReservationTime.FindAsync(id);
            return data;
        }

        public async Task<bool> CreateReservationTime(int id, ReservationTime reservationTime)
        {
            try
            {
                await _context.ReservationTime.AddAsync(reservationTime);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReservationTime> UpdateReservationTime(int id, ReservationTime reservationTime)
        {
            try
            {
                _context.Entry(reservationTime).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return reservationTime;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteReservationTime(int id, ReservationTime reservationTime)
        {
            try
            {
                _context.ReservationTime.Remove(reservationTime);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
