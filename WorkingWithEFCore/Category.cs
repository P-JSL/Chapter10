using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared;

public class Category
{
    //이 프로퍼티들은 DB 컬럼에 맵핑
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    [Column(TypeName ="nText")]
    public string? Description { get; set; }

    //관련된 행에 대한 탐색 프로퍼티
    public virtual ICollection<Product> Products { get; set; }

    public Category() 
    { 
        //개발자가 Category에 Product 추가하기 위한 탐색속성을 초기화
        Products  = new HashSet<Product>();
    }
}
