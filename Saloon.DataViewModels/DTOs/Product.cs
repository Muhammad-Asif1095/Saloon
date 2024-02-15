using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; } = null!;

    public virtual AspNetUsers? DeletedByNavigation { get; set; }

    public virtual ICollection<DiscountedProducts> DiscountedProducts { get; } = new List<DiscountedProducts>();

    public virtual AspNetUsers? ModifiedByNavigation { get; set; }
}
