using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PisiTechSchool.Data;
using PisiTechSchool.Models;

namespace PisiTechSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly PisiTechSchoolContext _context;

        public SubscriptionsController(PisiTechSchoolContext context)
        {
            _context = context;
        }


        // POST: api/Subscriptions
        [HttpPost("Subscribe")]
        [Authorize]
        public IActionResult Subscribe(int service_id, string phone_number)
        {

            var mySubscription = _context.Subscription.FirstOrDefault(u => u.ServiceId == service_id && u.PhoneNumber == phone_number);

            if (mySubscription != null)
            {
              return Conflict("User is already subscribed");
            }

            var subscribe = new Subscription()
            {

                ServiceId = service_id,
                PhoneNumber = phone_number,
                SubscribedDate = System.DateTime.Today,
                
            };

            _context.Subscription.Add(subscribe);
            _context.SaveChanges();
            return Ok("Subscription ID is: " + subscribe.SubscriptionId + " "+ " User is subscribed");

        }

        // Delete: api/Subscriptions
        [HttpDelete("Unsubscribe")]
        [Authorize]
        public IActionResult Unsubscribe(int service_id, string phone_number)
        {
          var mySubscription = _context.Subscription.FirstOrDefault(u => u.ServiceId == service_id && u.PhoneNumber == phone_number);

            if (mySubscription == null)
            {
                return BadRequest("User is not subscribed");

            }
            
            _context.Subscription.Remove(mySubscription);
            _context.SaveChanges(); 
            return Ok("User is Unsubscribed");
        }

        // PUT: api/Subscriptions         
        [HttpGet("CheckStatus")]
        [Authorize]
        public IActionResult CheckStatus(int service_id, string phone_number)
        {

            var mySubscription = _context.Subscription.FirstOrDefault(u => u.ServiceId == service_id && u.PhoneNumber == phone_number);

            if (mySubscription == null)
            {
                return BadRequest("User is not subscribed");

            }
            var thesubscribed = _context.Subscription;         
            var query = from t in thesubscribed                      
                        where t.ServiceId == service_id && t.PhoneNumber == phone_number

                        select new
                        {
                            t.SubscribedDate,
                            t.SubscriptionId,
                            t.PhoneNumber
                           
                        };

            var result = query.ToList();
            return Ok(result);
        }

    }
}
