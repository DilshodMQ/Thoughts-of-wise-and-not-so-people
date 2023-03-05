﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public Guid Uid { get; set; } = Guid.NewGuid();
    }
}
