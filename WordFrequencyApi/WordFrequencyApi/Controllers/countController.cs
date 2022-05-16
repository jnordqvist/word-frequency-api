using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WordFrequencyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class countController : ControllerBase
    {
        private readonly ILogger<countController> _logger;

        public countController(ILogger<countController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Post method, reads data from request, splits data on blankspace
        /// takes generated dictionary and serializes to json
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Post()
        {
            string input;
            using (var reader = new StreamReader(Request.Body))
            {
                input = await reader.ReadToEndAsync();
            }
            var words = input.Split();
            var wordCounts = GenerateFrequencyDictionary(words);

            return JsonConvert.SerializeObject(wordCounts);
        }

        /// <summary>
        /// takes list of words and generates a dictionary containing the frequency of each word in supplied list
        /// key = word & value = frequency
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        private static Dictionary<string, int> GenerateFrequencyDictionary(string[] words)
        {
            Dictionary<string, int> wordCounts = new();
            foreach (var word in words)
            {
                if (!wordCounts.ContainsKey(word))
                    wordCounts.Add(word, 1);
                else
                    wordCounts[word] += 1;
            }
            wordCounts = wordCounts.OrderByDescending(x => x.Value).Take(10).ToDictionary(x => x.Key, x => x.Value);
            return wordCounts;
        }
    }
}
