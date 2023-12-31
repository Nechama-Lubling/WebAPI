﻿using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {

        public int ProductId { get; set; }

        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }

        public decimal? Price { get; set; }

        public int? CategoryId { get; set; }

        public string? ProductDescription { get; set; }

        public string? Img { get; set; }


    }
    }
