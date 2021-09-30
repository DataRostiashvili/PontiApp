﻿using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Ponti.Repository.PontiRepository
{
    public class PlaceRepository : BaseRepository<PlaceEntity>
    {
        public PlaceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public async override Task InsertHosting(PlaceEntity currPlace)
        {
            await Insert(currPlace);

            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserHostPlaces)
                .SingleAsync(u => u.QueueId == currPlace.HostUser.QueueId);

            currUser.UserHostPlaces.Add(currPlace);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async override Task InsertGuesting(PlaceEntity currPlace)
        {

            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserHostPlaces)
                .SingleAsync(u => u.QueueId == currPlace.HostUser.QueueId);

            currUser.UserHostPlaces.Add(currPlace);
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}