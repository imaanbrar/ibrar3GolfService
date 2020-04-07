using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ibrar3GolfDataModel.Common;
using ibrar3GolfDataModel.Data;
using ibrar3GolfDataModel.Models;
using ibrar3GolfDataModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ibrar3GolfService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly GolfContext _context;

        public ScoresController(GolfContext context)
        {
            _context = context;
        }

        public async Task<double> GetHandicap(int userId)
        {
            var data = await _context.Scores.Where(x => x.UserId == userId).Select(x => new ScoresView
            {
                TotalScore = x.Hole1 + x.Hole2 + x.Hole3 + x.Hole4 + x.Hole5 + x.Hole6 + x.Hole7 + x.Hole8 + x.Hole9 + x.Hole10 + x.Hole11 + x.Hole12 + x.Hole13 + x.Hole14 + x.Hole15 + x.Hole16 + x.Hole17 + x.Hole18
            }).ToListAsync();

            var totalScore = data.Sum(x => x.TotalScore);
            var handicap = ((totalScore - Constants.CourseRating) / Constants.Slope) * 113;
            return handicap;
        }

        public async Task<List<ScoresView>> GetScoresView()
        {
            var data = await _context.Scores.Select(x => new ScoresView
            {
                Id = x.Id,
                UserId = x.UserId,
                DatePlayed = x.DatePlayed,
                UserName = x.User.Name,
                Hole1 = x.Hole1,
                Hole2 = x.Hole2,
                Hole3 = x.Hole3,
                Hole4 = x.Hole4,
                Hole5 = x.Hole5,
                Hole6 = x.Hole6,
                Hole7 = x.Hole7,
                Hole8 = x.Hole8,
                Hole9 = x.Hole9,
                Hole10 = x.Hole10,
                Hole11 = x.Hole11,
                Hole12 = x.Hole12,
                Hole13 = x.Hole13,
                Hole14 = x.Hole14,
                Hole15 = x.Hole15,
                Hole16 = x.Hole16,
                Hole17 = x.Hole17,
                Hole18 = x.Hole18,
                TotalScore = x.Hole1 + x.Hole2 + x.Hole3 + x.Hole4 + x.Hole5 + x.Hole6 + x.Hole7 + x.Hole8 + x.Hole9 + x.Hole10 + x.Hole11 + x.Hole12 + x.Hole13 + x.Hole14 + x.Hole15 + x.Hole16 + x.Hole17 + x.Hole18
            }).ToListAsync();
            return data;
        }

        public async Task<List<ScoresView>> GetScoresViewByUserId(int userId)
        {
            var data = await _context.Scores.Where(x => x.UserId == userId).Select(x => new ScoresView
            {
                Id = x.Id,
                UserId = x.UserId,
                DatePlayed = x.DatePlayed,
                UserName = x.User.Name,
                Hole1 = x.Hole1,
                Hole2 = x.Hole2,
                Hole3 = x.Hole3,
                Hole4 = x.Hole4,
                Hole5 = x.Hole5,
                Hole6 = x.Hole6,
                Hole7 = x.Hole7,
                Hole8 = x.Hole8,
                Hole9 = x.Hole9,
                Hole10 = x.Hole10,
                Hole11 = x.Hole11,
                Hole12 = x.Hole12,
                Hole13 = x.Hole13,
                Hole14 = x.Hole14,
                Hole15 = x.Hole15,
                Hole16 = x.Hole16,
                Hole17 = x.Hole17,
                Hole18 = x.Hole18,
                TotalScore = x.Hole1 + x.Hole2 + x.Hole3 + x.Hole4 + x.Hole5 + x.Hole6 + x.Hole7 + x.Hole8 + x.Hole9 + x.Hole10 + x.Hole11 + x.Hole12 + x.Hole13 + x.Hole14 + x.Hole15 + x.Hole16 + x.Hole17 + x.Hole18
            }).ToListAsync();
            return data;
        }

        [HttpPut]
        public async Task<IActionResult> PutScore([FromForm]int key, [FromForm] string values)
        {
            var Score = _context.Scores.FirstOrDefault(o => o.Id == key);
            if (Score == null)
                return StatusCode(409, "Item not found");

            JsonConvert.PopulateObject(values, Score);

            if (!TryValidateModel(Score))
                return BadRequest();

            await _context.SaveChangesAsync();

            return Ok(Score);
        }

        [HttpPost]
        public async Task<IActionResult> PostScore([FromForm] string values)
        {
            var newScore = new Scores();
            JsonConvert.PopulateObject(values, newScore);

            if (!TryValidateModel(newScore))
                return BadRequest();
            _context.Scores.Add(newScore);
            await _context.SaveChangesAsync();

            return Ok(newScore);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteScore([FromForm] int key)
        {
            try
            {
                var Score = _context.Scores.First(o => o.Id == key);
                _context.Scores.Remove(Score);
                await _context.SaveChangesAsync();

                return Ok(Score);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}