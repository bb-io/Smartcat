using System.Net;
using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Models.Dtos;
using Apps.Smartcat.Models.Responses;
using Apps.Smartcat.Webhooks.Handlers;
using Apps.Smartcat.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Smartcat.Webhooks;

[WebhookList]
public class WebhookList : SmartcatInvocable
{
    public WebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Webhook("On project status changed", typeof(ProjectStatusChangedHandler),
        Description = "Triggered when status of the specific project changed")]
    public async Task<WebhookResponse<ListProjectsResponse>> OnProjectStatusChanged(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectStatusChangedParameter input)
    {
        var projectIds = GetPayloadIds(webhookRequest);

        var result = new List<FullProjectDTO>();
        foreach (var projectId in projectIds)
        {
            var request = new SmartcatRequest(Urls.Api + "project/" + projectId, Method.Get, Creds);
            var project = await Client.ExecuteWithHandling<FullProjectDTO>(request);

            if ((input.Status is null || project.Status.Equals(input.Status, StringComparison.OrdinalIgnoreCase)) &&
                (input.ProjectId is null || project.Id == input.ProjectId) &&
                (input.ClientId is null || project.clientId == input.ClientId) &&
                (input.AccountId is null || project.accountId == input.AccountId))
                result.Add(project);
        }

        if (!result.Any())
            return new WebhookResponse<ListProjectsResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        return new WebhookResponse<ListProjectsResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new()
            {
                Projects = result
            },
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On document status changed", typeof(DocumentStatusChangedHandler),
        Description = "Triggered when status of the specific document changed")]
    public async Task<WebhookResponse<ListDocumentsResponse>> OnDocumentStatusChanged(WebhookRequest webhookRequest,
        [WebhookParameter] DocumentStatusChangedParameter input)
    {
        var documentIds = GetPayloadIds(webhookRequest);

        var result = new List<DocumentDto>();
        foreach (var documentId in documentIds)
        {
            var request = new SmartcatRequest(Urls.Api + "document/?documentId=" + documentId, Method.Get, Creds);
            var document = await Client.ExecuteWithHandling<DocumentDto>(request);

            if ((input.Status is null || document.Status.Equals(input.Status, StringComparison.OrdinalIgnoreCase)) &&
                (input.DocumentId is null || document.Id == input.DocumentId) &&
                (input.ProjectId is null || document.ProjectId == input.ProjectId) &&
                (input.SourceLanguage is null || document.SourceLanguage == input.SourceLanguage) &&
                (input.TargetLanguage is null || document.TargetLanguage == input.TargetLanguage))
                result.Add(document);
        }

        if (!result.Any())
            return new WebhookResponse<ListDocumentsResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        return new WebhookResponse<ListDocumentsResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new()
            {
                Documents = result
            },
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On translation XLIFF import completed", typeof(TranslationImportCompletedHandler),
        Description = "Triggered when XLIFF translation of the specific document completed")]
    public async Task<WebhookResponse<ListDocumentsResponse>> OnTranslationImportCompleted(
        WebhookRequest webhookRequest, [WebhookParameter] TranslationImportCompletedParameter input)
    {
        var documentIds = GetPayloadIds(webhookRequest);

        var result = new List<DocumentDto>();
        foreach (var documentId in documentIds)
        {
            var request = new SmartcatRequest(Urls.Api + "document/?documentId=" + documentId, Method.Get, Creds);
            var document = await Client.ExecuteWithHandling<DocumentDto>(request);

            if ((input.DocumentId is null || document.Id == input.DocumentId) &&
                (input.ProjectId is null || document.ProjectId == input.ProjectId) &&
                (input.SourceLanguage is null || document.SourceLanguage == input.SourceLanguage) &&
                (input.TargetLanguage is null || document.TargetLanguage == input.TargetLanguage))
                result.Add(document);
        }

        return new WebhookResponse<ListDocumentsResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new()
            {
                Documents = result
            },
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    private IEnumerable<string> GetPayloadIds(WebhookRequest webhookRequest)
    {
        return JsonConvert.DeserializeObject<IEnumerable<string>>(webhookRequest.Body.ToString()!) ??
               throw new Exception("No serializable payload was found in incoming request.");
    }
}