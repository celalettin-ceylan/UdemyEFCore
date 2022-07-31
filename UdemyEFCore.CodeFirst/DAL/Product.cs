using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL;

// once back migration yap update-database yaparak sonra remove-migrationlari silin. aradan silmek yok sondan sile sile gidiyorsun.
// script-migration ile database olusturdugumuz scriptleri olusturur. olusturulan scripleri sqlserverde calistirilip degisiklikleri direk uygulayabilirsiniz.

public class Product
{
    [Key]
    public int Id { get; set; }
    public String Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int Barcode { get; set; }
    public DateTime? CreatedDate { get; set; }
}
