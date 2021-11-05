using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using RingCentral;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace WebAPIClient {
  class Program {

    private static string RINGCENTRAL_CLIENTID = "";
    private static string RINGCENTRAL_CLIENTSECRET = "";
    private static bool RINGCENTRAL_PRODUCTION = true;
    private static string RINGCENTRAL_USERNAME = "";
    private static string RINGCENTRAL_PASSWORD = "";
    private static string RINGCENTRAL_EXTENSION = "";

    static RingCentral.RestClient rcClient;

    static void Main(string[] args){
      rcClient = new RingCentral.RestClient(RINGCENTRAL_CLIENTID, RINGCENTRAL_CLIENTSECRET, RINGCENTRAL_PRODUCTION);
      rcClient.Authorize(RINGCENTRAL_USERNAME, RINGCENTRAL_EXTENSION, RINGCENTRAL_PASSWORD).Wait();
      getAggregateData(rcClient.token);
      getTimelineData(rcClient.token);
    }   

    private static async void getAggregateData(TokenInfo token) {
      rcClient = new RingCentral.RestClient(RINGCENTRAL_CLIENTID, RINGCENTRAL_CLIENTSECRET, RINGCENTRAL_PRODUCTION);
      rcClient.token = token;
      var jsonRequestObject = loadJson();
      var response = await rcClient.Post("/analytics/phone/performance/v1/accounts/~/calls/aggregate", jsonRequestObject);
      Console.WriteLine("---- Aggregate Data ----");
      Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    private static void getTimelineData(TokenInfo token) {
      var restClient = new RestSharp.RestClient("https://platform.ringcentral.com/analytics/phone/performance/v1/accounts/~/calls/timeline?interval=Week");
      restClient.Timeout = -1;
      var request = new RestRequest(Method.POST);
      var jsonRequestObject = loadJson();
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Accept", "application/json");
      request.AddHeader("Authorization", "Bearer " + token.access_token);
      var body =  @"{" + "\n" +
                  @"  ""grouping"": {" + "\n" +
                  @"    ""groupBy"": ""Users""," + "\n" +
                  @"    ""ids"": []" + "\n" +
                  @"  }," + "\n" +
                  @"  ""timeRange"": {" + "\n" +
                  @"    ""timeFrom"": ""2021-05-18T05:53:49.150Z""," + "\n" +
                  @"    ""timeTo"": ""2021-10-27T05:53:49.150Z""" + "\n" +
                  @"  }," + "\n" +
                  @"  ""additionalFilters"": {" + "\n" +
                  @"    ""direction"": ""Inbound""," + "\n" +
                  @"    ""origin"": ""Internal""," + "\n" +
                  @"    ""callResponse"": ""Answered""," + "\n" +
                  @"    ""callResponseType"": [" + "\n" +
                  @"      ""InboundDirect""" + "\n" +
                  @"    ]," + "\n" +
                  @"    ""callResult"": [" + "\n" +
                  @"      ""Completed""" + "\n" +
                  @"    ]," + "\n" +
                  @"    ""callSegments"": [" + "\n" +
                  @"      {" + "\n" +
                  @"        ""callSegment"": ""Ringing""," + "\n" +
                  @"        ""callSegmentLength"": {" + "\n" +
                  @"          ""minValueSeconds"": 0," + "\n" +
                  @"          ""maxValueSeconds"": 200" + "\n" +
                  @"        }" + "\n" +
                  @"      }" + "\n" +
                  @"    ]," + "\n" +
                  @"    ""callActions"": [" + "\n" +
                  @"      {" + "\n" +
                  @"        ""callAction"": ""HoldOff""" + "\n" +
                  @"      }" + "\n" +
                  @"    ]," + "\n" +
                  @"    ""companyHours"": ""BusinessHours""," + "\n" +
                  @"    ""callDuration"": {" + "\n" +
                  @"      ""minValueSeconds"": 0," + "\n" +
                  @"      ""maxValueSeconds"": 200" + "\n" +
                  @"    }," + "\n" +
                  @"    ""timeSpent"": {" + "\n" +
                  @"      ""minValueSeconds"": 0," + "\n" +
                  @"      ""maxValueSeconds"": 200" + "\n" +
                  @"    }," + "\n" +
                  @"    ""callerExtensionIds"": []," + "\n" +
                  @"    ""calledExtensionIds"": []," + "\n" +
                  @"    ""calledNumbers"": []" + "\n" +
                  @"  }," + "\n" +
                  @"  ""responseOptions"": {" + "\n" +
                  @"    ""counters"": {" + "\n" +
                  @"      ""allCalls"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsByDirection"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsByOrigin"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsByResponse"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsByResponseType"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsSegments"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsByResult"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsByCompanyHours"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsByActions"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }" + "\n" +
                  @"    }," + "\n" +
                  @"    ""timers"": {" + "\n" +
                  @"      ""allCallsDuration"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsDurationByDirection"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsDurationByOrigin"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsDurationByResponse"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsDurationByResponseType"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsSegmentsDuration"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsDurationByResult"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }," + "\n" +
                  @"      ""callsDurationByCompanyHours"": {" + "\n" +
                  @"        ""aggregationType"": ""Sum""" + "\n" +
                  @"      }" + "\n" +
                  @"    }" + "\n" +
                  @"  }" + "\n" +
                  @"}" + "\n" +
                  @"";
      request.AddParameter("application/json", body, ParameterType.RequestBody);
      IRestResponse response = restClient.Execute(request);
      Console.WriteLine("---- Timeline Data ----");
      Console.WriteLine(response.Content);
    }

    // Helper function to load the JSON file, make sure to edit this based on your requirements
    private static JObject loadJson() {
      string filepath = "aggregate-data-request.json";
      string result = string.Empty;
      using (StreamReader r = new StreamReader(filepath)) {
        var jsonString = r.ReadToEnd();
        JObject jsonObject = JObject.Parse(jsonString);
        return jsonObject;
      }
    }
  }
}