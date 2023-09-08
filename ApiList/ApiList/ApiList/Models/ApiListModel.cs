﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiList.Models
{
    public class ApiListModel
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
