﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CoreAppSkeleton.Data.Common.Models
{
    public abstract class DeletableEntity : AuditInfo, IDeletableEntity
    {
        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }
    }
}
