﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutividadeApp.Models
{
    public class Emotion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Mood { get; set; }
    }
}
