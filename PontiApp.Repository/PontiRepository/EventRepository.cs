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
    public class EventRepository : BaseRepository<EventEntity>
    {
        public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext){
        
        }

        public async override Task InsertHosting(EventEntity currEvent)
        {
            await Insert(currEvent);

            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserHostEvents)
                .SingleAsync(u => u.QueueId == currEvent.HostUser.QueueId);

            var currPlace = await _applicationDbContext.Places
                .Include(p => p.PlaceEvents)
                .SingleAsync(p => p.QueueId == currEvent.Place.QueueId);

            currUser.UserHostEvents.Add(currEvent);
            currPlace.PlaceEvents.Add(currEvent);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async override Task InsertGuesting(EventEntity currEvent)
        {

            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserGuestEvents)
                .SingleAsync(u => u.QueueId == currEvent.HostUser.QueueId);

            currUser.UserHostEvents.Add(currEvent);
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}