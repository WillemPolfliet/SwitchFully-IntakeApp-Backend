﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.Campaigns
{
    public class Campaign
    {
        public Guid CampaignId { get; protected set; }
        public string Name { get; private set; }
        public string Client { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        private bool status;

        public bool Status
        {
            get
            {
                return SetStatusOfCampaign();
            }
            set
            {
                status = SetStatusOfCampaign();
            }
        }

        private Campaign() { }

		public Campaign(Guid campaignId, string name, string client, DateTime startDate, DateTime endDate)
		{
			CampaignId = campaignId;
			Name = name;
			Client = client;
			StartDate = startDate;
			EndDate = endDate;
			Status = status;
		}

		private  Campaign(string name, string client, DateTime startDate, DateTime endDate)
        {
            CampaignId = Guid.NewGuid();
            Name = name;
            Client = client;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

		public Campaign(Guid campaignId, string name)
		{
			CampaignId = campaignId;
			Name = name;
		}

		public static Campaign CreateNewCampaign(string name, string client, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(client) || startDate == null || endDate == null)
            {
                return null;
            }
            return new Campaign(name, client, startDate, endDate);
        }

	    public static Campaign CreateNewCampaign(Guid id, string name, string client, DateTime startDate, DateTime endDate)
	    {
		    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(client) || startDate == null || endDate == null)
		    {
			    return null;
		    }
		    return new Campaign(id, name, client, startDate, endDate);
	    }
        private bool SetStatusOfCampaign()
        {
            DateTime dateToday = DateTime.Now;

            return dateToday >= StartDate && dateToday <= EndDate ;
        }

    }
}
