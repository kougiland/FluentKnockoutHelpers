﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FluentKnockoutHelpers.Core.TypeMetadata;
using System.Data.Entity;
using SurveyApp.Model.Models;
using SurveyApp.Model.Services;
using SurveyApp.Web.Models;

namespace SurveyApp.Web.ApiControllers
{
    public class SurveyController : ApiController
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }


        // GET api/survey
        [ExcludeMetadata]
        public IEnumerable<SurveySummary> Get()
        {
            return _surveyService.GetSummaries();
        }

        // GET api/survey/5
        public Survey Get(string id)
        {
            return _surveyService.Get(id);
        }

        // POST api/survey
        public void Post(Survey survey)
        {
            _surveyService.Save(survey);
        }

        // DELETE api/survey/5
        public void Delete(string id)
        {
            _surveyService.Delete(id);
        }

        //  rpc/survey/ValidateIdNumberUnique
        [HttpPost]
        public KnockoutValidationResult ValidateIdNumberUnique(ValidatePersonIdNumberUnique dto)
        {
            return new KnockoutValidationResult(_surveyService.ValidatePersonIdNumberUnique(dto));
        }
    }
}
