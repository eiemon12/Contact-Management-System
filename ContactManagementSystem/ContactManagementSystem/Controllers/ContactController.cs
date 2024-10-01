using BLL.DTOs;
using BLL.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactManagementSystem.Auth;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using CsvHelper;

namespace ContactManagementSystem.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = ContactService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = ContactService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(ContactDTO obj)
        {
            try
            {
                var data = ContactService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}, Inner Exception: {innerException}");
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(ContactDTO obj)
        {
            try
            {
                var data = ContactService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = ContactService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("search/{name}")]
        public HttpResponseMessage Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Name cannot be null or empty.");
            }

            var contacts = ContactService.SearchByName(name);
            if (contacts == null || !contacts.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No contacts found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, contacts);
        }

        [HttpGet]
        [Route("export")]
        public HttpResponseMessage ExportContacts()
        {
            try
            {
                var contacts = ContactService.GetAll();
                var csv = new StringWriter();

                using (var writer = new CsvWriter(csv, CultureInfo.InvariantCulture))
                {
                    writer.WriteRecords(contacts);
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(csv.ToString())
                };

                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "contacts.csv"
                };

                return result;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error exporting contacts: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("import")]
        public HttpResponseMessage ImportContacts()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No file uploaded.");
                }

                var postedFile = httpRequest.Files[0];

                using (var reader = new StreamReader(postedFile.InputStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var contacts = csv.GetRecords<ContactDTO>().ToList();

                    foreach (var contact in contacts)
                    {
                        ContactService.Create(contact);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Contacts imported successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error importing contacts: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("reminders/{daysAhead}")]
        public HttpResponseMessage GetBirthdayReminders(int daysAhead)
        {
            try
            {
                var contacts = ContactService.GetUpcomingBirthdays(daysAhead);
                if (contacts == null || !contacts.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No upcoming birthdays found.");
                }
                return Request.CreateResponse(HttpStatusCode.OK, contacts);
            }
            catch (Exception ex)
            {
                
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while processing your request.");
            }
        }



    }
}
