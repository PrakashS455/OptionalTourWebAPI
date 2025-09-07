using System;
using System.Collections.Generic;
using FluentValidation;

namespace OptionalToursAPI.Api.Models
{
    public class AvailableShipsRequestModel
    {
        public int SHIP_ID { get; set; }
        public string SHIP_CODE { get; set; }
        public string SHIP_DESC { get; set; }

    }
}
