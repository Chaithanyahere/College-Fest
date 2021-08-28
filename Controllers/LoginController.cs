using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using College_Fest.Models;

namespace College_Fest.Controllers
{
    public class LoginController : Controller
    {
        private programEntities db = new programEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(register user)
        {
            bool result = db.registers.Any(u => u.username.Equals(user.username) && u.pasword.Equals(user.pasword));

            if (result)
            {
                register loggedUser = db.registers.First(u => u.username.Equals(user.username) && u.pasword.Equals(user.pasword));
                Session["username"] = loggedUser.username;
                Session["userid"] = loggedUser.rid;

                FormsAuthentication.SetAuthCookie(loggedUser.username, false);


                ViewBag.Message = "Login Successfull!!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Incorrect Username or password!!";
            }

            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "rid,firstname,lastname,phone,email,course,year,college,username,pasword")] register register)
        {
            if (ModelState.IsValid)
            {
                db.registers.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(register);
        }
       


private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Home");
        }
    }
}