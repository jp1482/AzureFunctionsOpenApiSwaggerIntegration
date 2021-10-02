namespace SampleBlogFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Azure.Functions.Worker.Http;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
    using Microsoft.Extensions.Logging;
    public class BlogFunctions
    {
        [Function("GetBlogItems")]
        [OpenApiOperation(operationId: nameof(GetBlogItems), Description = "Return all items.", Visibility = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiVisibilityType.Important)]
        [OpenApiSecurity("BearerAuth", Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey, In = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiSecurityLocationType.Header, Name = "Authorization")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(List<BlogItem>))]
        [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Unauthorized)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Forbidden)]
        public static HttpResponseData GetBlogItems([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "blogs")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }

        [Function("GetBlogItem")]
        [OpenApiOperation(operationId: nameof(GetBlogItem), Description = "Return blog item by guid.", Visibility = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiVisibilityType.Important)]
        [OpenApiSecurity("BearerAuth", Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey, In = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiSecurityLocationType.Header, Name = "Authorization")]
        [OpenApiParameter("id",Type = typeof(Guid))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(BlogItem))]
        [OpenApiResponseWithoutBody(HttpStatusCode.NotFound)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Unauthorized)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Forbidden)]
        public static HttpResponseData GetBlogItem([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "blogs/{id:Guid}")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }


        [Function("AddBlogItem")]
        [OpenApiOperation(operationId: nameof(AddBlogItem), Description = "Add new item.", Visibility = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiVisibilityType.Important)]
        [OpenApiSecurity("BearerAuth", Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey, In = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiSecurityLocationType.Header, Name = "Authorization")]
        [OpenApiRequestBody("application/json",typeof(BlogItem))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Unauthorized)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Forbidden)]
        public static HttpResponseData AddBlogItem([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "blogs")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }

        [Function("UpdateBlogItem")]
        [OpenApiOperation(operationId: nameof(UpdateBlogItem), Description = "Update Blog Item.", Visibility = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiVisibilityType.Important)]
        [OpenApiSecurity("BearerAuth", Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey, In = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiSecurityLocationType.Header, Name = "Authorization")]
        [OpenApiParameter("id", Type = typeof(Guid))]
        [OpenApiRequestBody("application/json",typeof(BlogItem))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Unauthorized)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Forbidden)]
        public static HttpResponseData UpdateBlogItem([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "blogs/{id:Guid}")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }

        [Function("DeleteBlogItem")]
        [OpenApiOperation(operationId: nameof(DeleteBlogItem), Description = "Delete Blog Item.", Visibility = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiVisibilityType.Important)]
        [OpenApiSecurity("BearerAuth", Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey, In = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiSecurityLocationType.Header, Name = "Authorization")]
        [OpenApiParameter("id", Type = typeof(Guid))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Unauthorized)]
        [OpenApiResponseWithoutBody(HttpStatusCode.Forbidden)]
        public static HttpResponseData DeleteBlogItem([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "blogs/{id:Guid}")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
