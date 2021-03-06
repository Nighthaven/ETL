﻿using System;
using System.Collections.Generic;
using System.Linq;

using ETL.BusinessObjects;
using ETL.ServicesWeb.Event;
using ETL.ServicesWeb.Services.Interfaces;

namespace ETL.ServicesWeb.Services
{
    internal class EventService : IEventService
    {
        #region Fields

        private readonly EventContractClient _client;

        #endregion

        #region Constructors

        internal EventService(EventContractClient pClient)
        {
            if (pClient == null) throw new ArgumentNullException("pClient");

            _client = pClient;
        }

        #endregion

        #region Methods

        #region Implemented

        public IEnumerable<IPosition> GetPositionsForToday(IAuthentificationToken pToken, IVehicule pVehicule)
        {
            if (pToken == null) throw new ArgumentNullException("pToken");

            var token = new Token() { Value = pToken.Value };

            var now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, DateTimeKind.Utc);
            var eventRequest = new EventRequest()
            {
                UnsafeToken = token,
                Vehicles = new[] { pVehicule.ID },
                StartDateTime = startDate,
                EndDateTime = endDate
            };

            var response = _client.GetPositionEvent(eventRequest);

            if (response == null) return Enumerable.Empty<IPosition>();

            return response.ConvertToPositions().ToList();
        }

        #endregion

        #endregion
    }
}