using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TriviaQuiz.Models;

namespace TriviaQuiz.Controllers
{
    public class TriviaQuizsController : Controller
    {
        // GET: TriviaQuizs
        public async Task<ActionResult> Index()
        {
            string Baseurl = "https://opentdb.com/api.php?amount=5&category=11&difficulty=medium&type=multiple";         
           
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(Baseurl);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    dynamic Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    TriviaQuestionOption TriviaQuestionOption = JsonConvert.DeserializeObject<TriviaQuestionOption>(Response);
                    ViewData["QuestionOption"] = TriviaQuestionOption;
                    return View(TriviaQuestionOption);
                }
                return View();
            }
        }
        [HttpPost]
        public ActionResult Submit(TriviaQuestionOption TriviaQuestionOption)
        {
            //Need to write some login here due to time not able to write if required please let me know i will update the code.
            return View();
        }
    }
}