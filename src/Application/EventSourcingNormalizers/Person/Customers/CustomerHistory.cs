﻿using Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Application.EventSourcingNormalizers.Person.Customers
{
    public static class CustomerHistory
    {
        public static IList<CustomerHistoryData> HistoryData { get; set; }

        public static IList<CustomerHistoryData> ToListJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CustomerHistoryData>();
            CustomerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var List = new List<CustomerHistoryData>();
            var Last = new CustomerHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new CustomerHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == Last.Id ? "" : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == Last.Name ? "" : change.Name,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == Last.Email ? "" : change.Email,
                    BirthDate = string.IsNullOrWhiteSpace(change.BirthDate) || change.BirthDate == Last.BirthDate ? "" : change.BirthDate.Substring(0, 10),

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };
                List.Add(jsSlot);
                Last = change;
            }
            return List;
        }
        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<CustomerHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {

                    case "CustomerRegisteredEvent":
                        historyData.Action = "Registered";
                        historyData.Who = e.User;
                        break;
                    case "CustomerUpdatedEvent":
                        historyData.Action = "Updated";
                        historyData.Who = e.User;
                        break;
                    case "CustomerRemovedEvent":
                        historyData.Action = "Removed";
                        historyData.Who = e.User;
                        break;
                    default:
                        historyData.Action = "Unrecognized";
                        historyData.Who = e.User ?? "Anonymous";
                        break;
                }
                HistoryData.Add(historyData);
            }
        }
    }
}
