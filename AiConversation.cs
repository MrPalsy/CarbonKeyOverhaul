using System;
using System.Net.Http;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Chat;
public class AiConversation
{
    private Conversation chat;
    public AiConversation()
    {
        string apiKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
        var api = new OpenAIAPI(apiKey);
        this.chat = api.Chat.CreateConversation();
        chat.AppendSystemMessage("You are a helpful assistant whos job is the suggest modification rules based on the input of the user.Here is an example of a rule insert into config.FactSpendEmissionsModificationRules(Country, SupplierId, SupplierName, UNSPSCClassId, JSONRule, Active)\r\nvalues(\r\nN'DK'\r\n,'CompanyID'\r\n,'CompanyName'\r\n,'83101800'\r\n,'{\"InvoicedQuantity_Adjusted\":\" a.InvoicedQuantity \",\r\n\"Unit_Adjusted\":\"case when i.Unit = ''KWH'' then ''EA'' else i.Unit end \"\r\n}'\r\n,2\r\n) This rule changes the unit from KWH to EA");
    }
    public async Task<string> GetResponse(string userInput)
    {
        chat.AppendUserInput(userInput);
        string response = await chat.GetResponseFromChatbotAsync();
        return response;
    }

}
