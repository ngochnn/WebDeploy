using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWeb.Models;
using System.Security.Cryptography;
using System.Text;


namespace ProjectWeb.Controllers
{
    public class UserController : Controller
    {
        dbshopgameEntities db = new dbshopgameEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel user)
        {
            try
            {
                dbshopgameEntities db = new dbshopgameEntities();
                if (ModelState.IsValid == true)
                {
                    UserManager usermanager = new UserManager();
                    if (usermanager.checkUserName(user.username) == false && usermanager.checkEmail(user.email) == false)/*chưa tồn tại nên tạo mới*/
                    {
                        Account newuser = new Account();
                        newuser.UserName = user.username;
                        newuser.Name = user.name;
                        newuser.Password = user.password;
                        newuser.Email = user.email;
                        //newuser.SĐT = user.SĐT;
                        //newuser.DiaChi = user.DiaChi;

                        //mã hóa password
                        SHA256 md5 = new SHA256CryptoServiceProvider();
                        Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(newuser.Password);
                        Byte[] encodedBytes = md5.ComputeHash(originalBytes);
                        newuser.Password = BitConverter.ToString(encodedBytes);

                        db.Accounts.Add(newuser);
                        db.SaveChanges();
                        //ViewBag.dangkythanhcong = "Đã đăng ký thành công";
                        //return View();
                        Session["Register"] = "Đăng kí thành công";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //return View("FailRegister");
                        ModelState.AddModelError("RegisterFail", "Tài khoản đã tồn tại");
                        ViewBag.error = "Tai khoan da ton tai";
                    }
                    ViewBag.dangkythanhcong = "đã đăng ký thành công";
                }                
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        public ActionResult FailRegister()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                string taikhoan = fc["TxtTaikhoan"].ToString();
                string matkhau = fc["TxtMatkhau"].ToString();

                SHA256 md5 = new SHA256CryptoServiceProvider();
                Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(matkhau);
                Byte[] encodedBytes = md5.ComputeHash(originalBytes);
                matkhau = BitConverter.ToString(encodedBytes);

                Account user = db.Accounts.SingleOrDefault(x => x.UserName == taikhoan && x.Password == matkhau);

                if (user != null)
                {
                    Session["Logged"] = "Xin chào" + " " + user.Name;



                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("Login", "User name hoặc password sai");
                    ViewBag.thongbao = "Tên tài khoản hoặc mật khẩu sai";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["Logged"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}