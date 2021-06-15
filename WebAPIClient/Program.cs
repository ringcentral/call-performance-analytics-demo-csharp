
using System;
using RestSharp;
using RestSharp.Authenticators;

namespace WebAPIClient {
  class Program {
    static void Main(string[] args) {
      var client = new RestClient("https://platform.ringcentral.com/restapi/v1.0/account/~/analytics/performance/calls/aggregate");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Accept", "application/json");
      request.AddHeader("Authorization", "Your Bearer Token goes here");
      var body = @"{" + "\n" +
                 @"  ""grouping"": {" + "\n" +
                 @"    ""groupBy"": ""CompanyNumbers""," + "\n" +
                 @"    ""identifiers"": [" + "\n" +
                 @"      ""string""" + "\n" +
                 @"    ]" + "\n" +
                 @"  }," + "\n" +
                 @"  ""timeRange"": {" + "\n" +
                 @"    ""timeFrom"": ""2021-05-01T08:01:21.453Z""," + "\n" +
                 @"    ""timeTo"": ""2021-05-20T08:01:21.453Z""" + "\n" +
                 @"  }," + "\n" +
                 @"  ""additionalFilters"": {" + "\n" +
                 @"    ""direction"": ""Inbound""," + "\n" +
                 @"    ""origin"": ""Internal""," + "\n" +
                 @"    ""callResponse"": ""Answered""," + "\n" +
                 @"    ""callResponseType"": [" + "\n" +
                 @"      ""InboundAnswers""" + "\n" +
                 @"    ]," + "\n" +
                 @"    ""callResult"": {" + "\n" +
                 @"      ""isEnded"": true," + "\n" +
                 @"      ""isAbandoned"": true," + "\n" +
                 @"      ""isVoiceMail"": true," + "\n" +
                 @"      ""isConnected"": true" + "\n" +
                 @"    }," + "\n" +
                 @"    ""companyHours"": ""BusinessHours""," + "\n" +
                 @"    ""callDuration"": {" + "\n" +
                 @"      ""minValueSeconds"": 0," + "\n" +
                 @"      ""maxValueSeconds"": 0" + "\n" +
                 @"    }," + "\n" +
                 @"    ""timeSpent"": {" + "\n" +
                 @"      ""minValueSeconds"": 0," + "\n" +
                 @"      ""maxValueSeconds"": 0" + "\n" +
                 @"    }" + "\n" +
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
                 @"      ""callsByResult"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }," + "\n" +
                 @"      ""callsByActions"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }" + "\n" +
                 @"    }," + "\n" +
                 @"    ""timers"": {" + "\n" +
                 @"      ""totalCallLength"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }," + "\n" +
                 @"      ""timeSpentByCallSegments"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }," + "\n" +
                 @"      ""callLengthByDirection"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }," + "\n" +
                 @"      ""callLengthByOrigin"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }," + "\n" +
                 @"      ""callLengthByResponse"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }," + "\n" +
                 @"      ""callLengthByResponseType"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }," + "\n" +
                 @"      ""callLengthByResult"": {" + "\n" +
                 @"        ""aggregationType"": ""Sum""" + "\n" +
                 @"      }" + "\n" +
                 @"    }" + "\n" +
                 @"  }" + "\n" +
                 @"}";
        
      request.AddParameter("application/json", body,  ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      Console.WriteLine(response.Content);       
    }
  }
}