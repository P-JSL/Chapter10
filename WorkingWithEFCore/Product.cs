using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Packt.Shared;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    [Column("UnitPrice",TypeName ="money")]
    public decimal? Cost { get; set; } //속성이름 != 컬럼이름

    [Column("UnitsInStock")]
    public short? Stock { get; set; }

    public bool Discontinued { get; set; }

    //Categoies의 외래키 관계 정의
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}
