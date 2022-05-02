using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels.Players;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly FootballManagerDbContext data;
        private readonly IValidator validator;
        private readonly IPlayersService playerService;
        public PlayersController(FootballManagerDbContext data, IValidator validator, IPasswordHasher passwordHasher, IPlayersService playerService)
        {
            this.data = data;
            this.validator = validator;
            this.playerService = playerService;
        }


        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(PlayerCreateForm model)
        {

            var modelErrors = this.validator.ValidatePlayer(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            this.data.Players.Add(player);
            this.data.SaveChanges();

            return Redirect("/Players/All");

        }

        [Authorize]
        public HttpResponse All()
        {
            var player = data.Players
                .Select(t => new PlayerAllForm
                {
                    Id = t.Id,
                    FullName=t.FullName,
                    Endurance=t.Endurance,
                    ImageUrl =  t.ImageUrl,
                    Speed = t.Speed,
                    Position = t.Position

                }).ToList();


            if (player == null)
            {
                return BadRequest();
            }
            return View(player);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var player = data.Players
             .Select(t => new MyCollectionView
             {
                 Id = t.Id,
                 FullName = t.FullName,
                 Endurance = t.Endurance,
                 ImageUrl = t.ImageUrl,
                 Speed = t.Speed,
                 Position = t.Position

             }).ToList();


            if (player == null)
            {
                return BadRequest();
            }
            return View(player);
        }


        [Authorize]
        public HttpResponse AddToCollection(string playerId)
        {
            try
            {
                playerService.AddToCollection(playerId, this.User.Id);
            }
            catch (Exception aex)
            {
                return Error(aex.Message);
            }

            return Redirect("/Players/All");
        }



        [Authorize]
        public HttpResponse RemoveFromCollection(string playerId)
        {
            var commit = this.data.Players.Find(playerId);

            if (commit == null)
            {
                return BadRequest();
            }

            this.data.Players.Remove(commit);

            this.data.SaveChanges();

            return Redirect("/Players/Collection");
        }
    }

}
