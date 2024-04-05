using JP.Data;
using JP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JP.Controllers
{
    public class WebController : Controller
    {

        private dbcontext s2;

        public WebController(dbcontext dbcontext)
        {
            s2 = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(ContactModel user)
        {
            s2.Contacts.Add(user);
            s2.SaveChanges();

            return RedirectToAction("Home");
        }

        public IActionResult Services()
        {
            return View();
        }
        public IActionResult FindEvents()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel abc)
        {
            var user=s2.Registers.FirstOrDefault(u=>u.Username==abc.Username && u.Password==abc.Password);
            if(user != null)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View(abc);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserModel user)
        {
            s2.Registers.Add(user);
            s2.SaveChanges();

            return RedirectToAction("Login");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Booking(BookingModel abc)
        {
            s2.Booking.Add(abc);
            s2.SaveChanges();

            return RedirectToAction("Home");
        }

        public IActionResult EventCard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminEvent()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminEvent(AdminEvent abc)
        {
            s2.AdminEvent.Add(abc);
            s2.SaveChanges();

            return RedirectToAction("AdminEvent");
        }
        public IActionResult AdminHome()
        {
            return View();
        }

        //For Update data In the admincrud Table
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            var eventDetails = s2.Booking.FirstOrDefault(e => e.Id == id);

            if (eventDetails == null)
            {
                // Event not found, return appropriate view or redirect
                return NotFound();
            }

            return View(eventDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(BookingModel admincrud)
        {
            if (!ModelState.IsValid)
            {
                // If model state is not valid, return the same view with validation errors
                return View(admincrud);
            }

            // Update the event details in the database
            s2.Entry(admincrud).State = EntityState.Modified;

            try
            {
                s2.SaveChanges();
                // If update is successful, redirect to a success page or action method
                return RedirectToAction("EditEvent", "Web");
            }
            catch (Exception ex)
            {
                // If update fails, return the same view with appropriate message
                ModelState.AddModelError(string.Empty, $"Failed to update event: {ex.Message}");
                return View(admincrud);
            }
        }

            public IActionResult Userdata()
        {
            IEnumerable<UserModel> abc = s2.Registers;
            return View(abc);
        }

		public IActionResult BookingData()
		{
			IEnumerable<BookingModel> abc = s2.Booking;
			return View(abc);
		}

		public IActionResult Feedback()
		{
			IEnumerable<ContactModel> abc = s2.Contacts;
			return View(abc);
		}

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user=await s2.Contacts.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            s2.Contacts.Remove(user);
            await s2.SaveChangesAsync();
            return RedirectToAction("Feedback");
        }

		[HttpPost]
		public async Task<IActionResult> Delete1(int id)
		{
			var user = await s2.Booking.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			s2.Booking.Remove(user);
			await s2.SaveChangesAsync();
			return RedirectToAction("BookingData");
		}
        [HttpPost]
        public IActionResult YourSaveAction(BookingModel model)
        {
            // Retrieve the entity from the database
            var booking = s2.Booking.FirstOrDefault(b => b.Id == model.Id);
            if (booking != null)
            {
                // Update the entity with new data
                booking.Username = model.Username;
                booking.Email = model.Email;
                booking.MobileNo = model.MobileNo;
                booking.EventName = model.EventName;
                booking.Date = model.Date;
                booking.EventPlace = model.EventPlace;

                // Save changes to the database
                s2.SaveChanges();

                // Return success response
                return Ok();
            }
            else
            {
                // Return error response if the entity is not found
                return NotFound();
            }
        }


    }
}
