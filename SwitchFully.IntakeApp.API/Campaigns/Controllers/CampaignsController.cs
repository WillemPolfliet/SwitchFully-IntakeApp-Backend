﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using SwitchFully.IntakeApp.API.Interfaces;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Service.Campaigns;

namespace SwitchFully.IntakeApp.API.Campaigns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase, IController<Campaign, CampaignDTO_Return>
    {
        private readonly ICampaignService _campaignService;
        private readonly ICampaignMapper _campaignMapper;

        public CampaignsController(ICampaignService campaignService, ICampaignMapper campaignMapper)
        {
            _campaignService = campaignService;
            _campaignMapper = campaignMapper;
        }


        // GET: api/Campaigns/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Campaigns
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Campaigns/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public ActionResult<List<CampaignDTO_Return>> GetAll()
        {
            return _campaignMapper.CampaignListToCampaignDTOReturnList(_campaignService.GetAllCampaigns());
        }

        public ActionResult<CampaignDTO_Return> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<CampaignDTO_Return> Update(Campaign objectToUpdate)
        {
            throw new NotImplementedException();
        }

        public ActionResult<CampaignDTO_Return> Create(Campaign objectToCreate)
        {
            throw new NotImplementedException();
        }
    }
}