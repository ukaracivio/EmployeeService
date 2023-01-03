using EmployeeService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Controllers
{
    // CRUD işlemleri Create, Read, Update, Delete

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet] // Select
        public List<Employee> Get()
        {
            // db tarafındaki Employee tablosunun tüm içeriğini bir listeye yükleyecek ve geri gönderecek..

            using (NorthwindContext db=new NorthwindContext())
            {
                return db.Employees.ToList();
            }
        }

        [HttpGet("{id}")] // Select
        public Employee Get(int id)
        {
            // db tarafındaki Employee tablosunun ilgili kayıdı (istenen) getirecek...

            using (NorthwindContext db = new NorthwindContext())
            {
                return db.Employees.Find(id);
            }
        }

        [HttpPost] // Insert 
        public IActionResult Post([FromBody] Employee obj)
        {
            // db tarafına View ekranından gelen employee bilgilerini db tarafına göndermeyi sağlayacak....

            using (NorthwindContext db = new NorthwindContext())
            {
                db.Employees.Add(obj);
                db.SaveChanges(); // arafta duran bilgiyi kalıcı olarak db tablosuna yerleştirme...

                return new ObjectResult("Employee bilgisi başarılı olarak kayıt edildi....");
            }
        }


        [HttpPut] // Update 
        public IActionResult Put(int id,[FromBody] Employee obj)
        {
            // db tarafına View ekranından gelen employee bilgilerini gelen parametreye öre ilgili kayıt için update işlemi yapar....

            using (NorthwindContext db = new NorthwindContext())
            {
                db.Entry<Employee>(obj).State = EntityState.Modified;
                db.SaveChanges(); // arafta duran bilgiyi kalıcı olarak db tablosuna yerleştirme...

                return new ObjectResult("Employee bilgisi başarılı olarak güncellendi ....");
            }
        }

        [HttpDelete] // Delete 
        public IActionResult Delete(int id)
        {
            // db tarafına View ekranından gelen employee bilgilerini gelen parametreye göre ilgili kayıdı siler ....

            using (NorthwindContext db = new NorthwindContext())
            {
                db.Employees.Remove(db.Employees.Find(id)); // Önce bir ara bulursan da kayıdı sil...
                db.SaveChanges(); // arafta duran bilgiyi kalıcı olarak db tablosundan silme...

                return new ObjectResult("Employee bilgisi başarılı olarak silindi....");
            }
        }

    }
}
