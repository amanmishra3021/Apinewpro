using Apinewpro.DB_context_ef;
using Apinewpro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Apinewpro.Controllers
{
   
   
    public class APIViewController : ApiController
    {
        [HttpGet]
        [Route("get/employee")]
        public List<employee> getview()
        {
            List<mymodel> mod = new List<mymodel>();

            Company_2Entities1 ent = new Company_2Entities1();
            var data = ent.employees.ToList();
         
      
            //foreach (var item in data)
            //{
            //    mod.Add(new mymodel
            //    {
            //        id = item.id,
            //        name=item.name,
            //        email=item.email,
            //        mobile=item.mobile,
            //        department=item.department,
            //        city=item.city

            //    }) ;

            

            return data;
        }
        [HttpPost]
        [Route("Emp/SaveEmployee")]
        public HttpResponseMessage SaveEmp(employee Obj)
        {

            Company_2Entities1 ent = new Company_2Entities1();
            employee tblEmp = new employee();
            if (Obj.id == 0)
            {

                ent.employees.Add(Obj);
                ent.SaveChanges();
            }
            else
            {
                ent.Entry(tblEmp).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();
            }
           
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);

            return res;
           


        }

    }
}